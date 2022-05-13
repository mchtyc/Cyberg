using System.Collections.Generic;
using UnityEngine;

public class KeyBox : MonoBehaviour
{
    public BoxData keyBox;
    MenuManager_Master MM_Master;

    void OnEnable()
    {
        MM_Master = GetComponentInParent<MenuManager_Master>();
        MM_Master.EventRestartKeyBox += setInitialValues;
    }

    void Start()
    {
        setInitialValues();
    }

    void setInitialValues()
    {
        if (keyBox.State == BoxState.Opening)
        {
            MM_Master.CallEventUpdateKeyBox();
        }
        else if (keyBox.State == BoxState.Opened)
        {
            MM_Master.CallEventOpenKeyBox();
        }
        else
        {
            keyBox.createBox();
            MM_Master.CallEventUpdateKeyBox();
        }
    }

    void OnDisable()
    {
        MM_Master.EventRestartKeyBox -= setInitialValues;
    }

    public void getKey()
    {
        if (keyBox.CurrentCount < keyBox.MaxCount)
        {
            keyBox.CurrentCount++;

            if (keyBox.CurrentCount == keyBox.MaxCount)
            {
                MM_Master.CallEventOpenKeyBox();
                keyBox.State = BoxState.Opened;
            }
            else
            {
                MM_Master.CallEventUpdateKeyBox();
            }
        }
    }
}
