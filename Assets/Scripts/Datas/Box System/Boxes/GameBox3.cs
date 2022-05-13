using System;
using System.Collections.Generic;
using UnityEngine;

public class GameBox3 : MonoBehaviour
{
    public BoxData gameBox3;
    MenuManager_Master MM_Master;

    double minutes, seconds;

    void OnEnable()
    {
        MM_Master = GetComponentInParent<MenuManager_Master>();
        MM_Master.EventRestartGameBox3 += setInitialValues;
        //gameBox3.RemainingTime = TimeSpan.FromSeconds(5);  //Deneme amaçlı
    }

    void Start()
    {
        setInitialValues();
    }

    void setInitialValues()
    {
        if (gameBox3.State == BoxState.Opening)
        {
            MM_Master.CallEventUpdateGameBox3();

            minutes = gameBox3.RemainingTime.Minutes;
            seconds = gameBox3.RemainingTime.Seconds;
        }
        else if (gameBox3.State == BoxState.Opened)
        {
            MM_Master.CallEventOpenGameBox3();
        }
        else if (gameBox3.State == BoxState.Waiting)
        {
            MM_Master.CallEventWaitingGameBox3();
        }
    }

    void OnDisable()
    {
        MM_Master.EventRestartGameBox3 -= setInitialValues;
    }

    void Update()
    {
        if (gameBox3.State == BoxState.Opening)
        {
            if (gameBox3.RemainingTime.TotalSeconds > 0)
            {
                gameBox3.RemainingTime = gameBox3.RemainingTime.Subtract(TimeSpan.FromSeconds(Time.unscaledDeltaTime));

                if (gameBox3.RemainingTime.TotalMinutes < 1 && gameBox3.RemainingTime.Seconds != seconds)
                {
                    seconds = gameBox3.RemainingTime.Seconds;
                    MM_Master.CallEventUpdateGameBox3();
                }
                else if (gameBox3.RemainingTime.Minutes != minutes)
                {
                    seconds = gameBox3.RemainingTime.Seconds;
                    minutes = gameBox3.RemainingTime.Minutes;
                    MM_Master.CallEventUpdateGameBox3();
                }
            }
            else
            {
                gameBox3.State = BoxState.Opened;
                MM_Master.CallEventOpenGameBox3();
            }
        }
    }
}
