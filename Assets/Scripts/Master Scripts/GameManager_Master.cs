using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Master : MonoBehaviour
{
    public delegate void GameManagerEventHandler();
    public delegate void GameManagerEventFireButton(bool b);
    public delegate void GameManagerEventPlayerHandler(Transform player);

    public event GameManagerEventHandler EventMenuToggle;
    public event GameManagerEventHandler EventRestartLevel;
    public event GameManagerEventHandler EventGoToMenuScene;
    public event GameManagerEventHandler EventGameOver;
    public event GameManagerEventHandler EventStartNewWave;
    public event GameManagerEventHandler EventWavesFinished;

    public event GameManagerEventFireButton EventFireButtonHold;

    public event GameManagerEventPlayerHandler EventOnPlayerBorn;

    public void CallEventMenuToggle()
    {
        if (EventMenuToggle != null)
        {
            EventMenuToggle();
        }
    }

    public void CallEventRestartLevel()
    {
        if (EventRestartLevel != null)
        {
            EventRestartLevel();
        }
    }

    public void CallEventGoToMenuScene()
    {
        if (EventGoToMenuScene != null)
        {
            EventGoToMenuScene();
        }
    }

    public void CallEventGameOver()
    {
        if (EventGameOver != null)
        {
            EventGameOver();
        }
    }

    public void CallEventFireButtonHold(bool b)
    {
        if (EventFireButtonHold != null)
        {
            EventFireButtonHold(b);
        }
    }

    public void CallEventOnPlayerBorn(Transform player)
    {
        if (EventOnPlayerBorn != null)
        {
            EventOnPlayerBorn(player);
        }
    }

    public void CallEventStartNewWave()
    {
        if (EventStartNewWave != null)
        {
            EventStartNewWave();
        }
    }

    public void CallEventWavesFinished()
    {
        if (EventWavesFinished != null)
        {
            EventWavesFinished();
        }
    }
}
