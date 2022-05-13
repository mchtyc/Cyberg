using System;
using System.Collections.Generic;
using UnityEngine;

public class GameBox2 : MonoBehaviour
{
    public BoxData gameBox2;
    MenuManager_Master MM_Master;

    double minutes, seconds;

    void OnEnable()
    {
        MM_Master = GetComponentInParent<MenuManager_Master>();
        MM_Master.EventRestartGameBox2 += setInitialValues;
        //gameBox1.RemainingTime = TimeSpan.FromSeconds(40);  //Deneme amaçlı
    }

    void Start()
    {
        setInitialValues();
    }

    void setInitialValues()
    {
        if (gameBox2.State == BoxState.Opening)
        {
            MM_Master.CallEventUpdateGameBox2();

            minutes = gameBox2.RemainingTime.Minutes;
            seconds = gameBox2.RemainingTime.Seconds;
        }
        else if (gameBox2.State == BoxState.Opened)
        {
            MM_Master.CallEventOpenGameBox2();
        }
        else if (gameBox2.State == BoxState.Waiting)
        {
            MM_Master.CallEventWaitingGameBox2();
        }
    }

    void OnDisable()
    {
        MM_Master.EventRestartGameBox2 -= setInitialValues;
    }

    void Update()
    {
        if (gameBox2.State == BoxState.Opening)
        {
            if (gameBox2.RemainingTime.TotalSeconds > 0)
            {
                gameBox2.RemainingTime = gameBox2.RemainingTime.Subtract(TimeSpan.FromSeconds(Time.unscaledDeltaTime));

                if (gameBox2.RemainingTime.TotalMinutes < 1 && gameBox2.RemainingTime.Seconds != seconds)
                {
                    seconds = gameBox2.RemainingTime.Seconds;
                    MM_Master.CallEventUpdateGameBox2();
                }
                else if (gameBox2.RemainingTime.Minutes != minutes)
                {
                    seconds = gameBox2.RemainingTime.Seconds;
                    minutes = gameBox2.RemainingTime.Minutes;
                    MM_Master.CallEventUpdateGameBox2();
                }
            }
            else
            {
                gameBox2.State = BoxState.Opened;
                MM_Master.CallEventOpenGameBox2();
            }
        }
    }
}
