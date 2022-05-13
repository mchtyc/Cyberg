using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBox : MonoBehaviour
{
    public BoxData missionBox;
    MenuManager_Master MM_Master;

    void OnEnable()
    {
        MM_Master = GetComponentInParent<MenuManager_Master>();
        MM_Master.EventRestartMissionBox += setInitialValues;
    }

    void Start()
    {
        setInitialValues();
    }

    void setInitialValues()
    {
        if (missionBox.State == BoxState.Opening)
        {
            MM_Master.CallEventUpdateMissionBox();
        }
        else if (missionBox.State == BoxState.Opened)
        {
            MM_Master.CallEventOpenMissionBox();
        }
    }

    void OnDisable()
    {
        MM_Master.EventRestartMissionBox -= setInitialValues;
    }

    public void missionCompleted()
    {
        if (missionBox.CurrentCount < missionBox.MaxCount)
        {
            missionBox.CurrentCount++;

            if (missionBox.CurrentCount == missionBox.MaxCount)
            {
                MM_Master.CallEventOpenMissionBox();
                missionBox.State = BoxState.Opened;
            }
            else
            {
                MM_Master.CallEventUpdateMissionBox();
            }
        }
    }
}
