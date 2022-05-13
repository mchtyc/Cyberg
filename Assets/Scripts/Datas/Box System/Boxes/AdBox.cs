using System;
using System.Collections.Generic;
using UnityEngine;

public class AdBox : MonoBehaviour
{
    public BoxData adBox;
    MenuManager_Master MM_Master;

    void OnEnable()
    {
        MM_Master = GetComponentInParent<MenuManager_Master>();

        MM_Master.EventRestartAdBox += setInitialValues;
    }

    void Start()
    {
        setInitialValues();
    }

    void setInitialValues()
    {
        if (adBox.State == BoxState.Opening)
        {
            MM_Master.CallEventUpdateAdBox();
        }
        else if (adBox.State == BoxState.Opened)
        {
            MM_Master.CallEventOpenAdBox();
        }
    }

    void OnDisable()
    {
        MM_Master.EventRestartAdBox -= setInitialValues;
    }

    public void adSuccessful()
    {
        if (adBox.CurrentCount < adBox.MaxCount) 
        {
            adBox.CurrentCount++;

            if (adBox.CurrentCount == adBox.MaxCount)
            {
                MM_Master.CallEventOpenAdBox();
                adBox.State = BoxState.Opened;
            }
            else
            {
                MM_Master.CallEventUpdateAdBox();
            } 
        }
    }
}
