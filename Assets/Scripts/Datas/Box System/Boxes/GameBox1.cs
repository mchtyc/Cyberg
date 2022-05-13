using System;
using System.Collections.Generic;
using UnityEngine;

public class GameBox1 : MonoBehaviour
{
    public BoxData gameBox1;
    MenuManager_Master MM_Master;

    double minutes, seconds;

    void OnEnable()
    {
        MM_Master = GetComponentInParent<MenuManager_Master>();
        MM_Master.EventRestartGameBox1 += setInitialValues;
        //gameBox1.RemainingTime = TimeSpan.FromSeconds(40);  //Deneme amaçlı
    }

    void Start()
    {
        setInitialValues();
    }

    void setInitialValues()
    {
        if (gameBox1.State == BoxState.Opening)
        {
            MM_Master.CallEventUpdateGameBox1();

            minutes = gameBox1.RemainingTime.Minutes;
            seconds = gameBox1.RemainingTime.Seconds;
        }
        else if (gameBox1.State == BoxState.Opened)
        {
            MM_Master.CallEventOpenGameBox1();
        }
        else if (gameBox1.State == BoxState.Waiting)
        {
            MM_Master.CallEventWaitingGameBox1();
        }
    }

    void OnDisable()
    {
        MM_Master.EventRestartGameBox1 -= setInitialValues;
    }

    void Update()
    {
        if (gameBox1.State == BoxState.Opening)
        {
            if (gameBox1.RemainingTime.TotalSeconds > 0)
            {
                gameBox1.RemainingTime = gameBox1.RemainingTime.Subtract(TimeSpan.FromSeconds(Time.unscaledDeltaTime));

                if (gameBox1.RemainingTime.TotalMinutes < 1 && gameBox1.RemainingTime.Seconds != seconds)
                {
                    seconds = gameBox1.RemainingTime.Seconds;
                    MM_Master.CallEventUpdateGameBox1();
                }
                else if (gameBox1.RemainingTime.Minutes != minutes)
                {
                    seconds = gameBox1.RemainingTime.Seconds;
                    minutes = gameBox1.RemainingTime.Minutes;
                    MM_Master.CallEventUpdateGameBox1();
                }
            }
            else
            {
                gameBox1.State = BoxState.Opened;
                MM_Master.CallEventOpenGameBox1();
            }
        }
    }
}
