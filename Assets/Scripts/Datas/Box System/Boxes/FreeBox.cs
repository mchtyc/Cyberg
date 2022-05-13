using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class FreeBox : MonoBehaviour
{
    public BoxData freeBox;

    MenuManager_Master MM_Master;
    double minutes, seconds;
    
    void OnEnable()
    {
        MM_Master = GetComponentInParent<MenuManager_Master>();

        MM_Master.EventRestartFreeBox += setInitialValues;
    }

    void Start()
    {
        setInitialValues();
    }

    void setInitialValues()
    {
        if (freeBox.State == BoxState.Opening)
        {
            MM_Master.CallEventUpdateFreeBox();

            minutes = freeBox.RemainingTime.Minutes;
            seconds = freeBox.RemainingTime.Seconds;
        }
        else if (freeBox.State == BoxState.Opened)
        {
            MM_Master.CallEventOpenFreeBox();
        }
    }

    void OnDisable()
    {
        MM_Master.EventRestartFreeBox -= setInitialValues;
    }

    void Update()
    {
        if (freeBox.State == BoxState.Opening)
        {
            if (freeBox.RemainingTime.TotalSeconds > 0)
            {
                freeBox.RemainingTime = freeBox.RemainingTime.Subtract(TimeSpan.FromSeconds(Time.unscaledDeltaTime));
                
                if (freeBox.RemainingTime.TotalMinutes < 1 && freeBox.RemainingTime.Seconds != seconds)
                {
                    seconds = freeBox.RemainingTime.Seconds;
                    MM_Master.CallEventUpdateFreeBox();
                }
                else if (freeBox.RemainingTime.Minutes != minutes)
                {
                    seconds = freeBox.RemainingTime.Seconds;
                    minutes = freeBox.RemainingTime.Minutes;
                    MM_Master.CallEventUpdateFreeBox();
                }
            }
            else
            {
                freeBox.State = BoxState.Opened;
                MM_Master.CallEventOpenFreeBox();
            }
        }
    }
}