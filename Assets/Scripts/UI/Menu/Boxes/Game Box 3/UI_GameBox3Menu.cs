using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameBox3Menu : BoxMenuBase
{
    public BoxData gameBox3;
    public MenuManager_Master MM_Master;

    UI_BoxMenu boxMenu;

    void OnEnable()
    {
        boxMenu = GetComponent<UI_BoxMenu>();

        MM_Master.EventUpdateGameBox3 += countDown;
        MM_Master.EventOpenGameBox3 += timerFinished;
        MM_Master.EventWaitingGameBox3 += startOpeningGameBox3;

        SetBoxMenuReferences();
    }

    void OnDisable()
    {
        MM_Master.EventUpdateGameBox3 -= countDown;
        MM_Master.EventOpenGameBox3 -= timerFinished;
        MM_Master.EventWaitingGameBox3 -= startOpeningGameBox3;
    }

    public void SetBoxMenuReferences()
    {
        if (gameBox3.State == BoxState.Opening)
        {
            boxMenu.setButtonInteractable(false);
            boxMenu.setButtonText(MenuManager_Time.Format(gameBox3.RemainingTime));
        }
        else if(gameBox3.State == BoxState.Opened)
        {
            boxMenu.setButtonInteractable(true);
            boxMenu.setButtonText("OPEN");
        }
        else if (gameBox3.State == BoxState.Waiting)
        {
            boxMenu.setButtonInteractable(true);
            boxMenu.setButtonText("START");
        }

        boxMenu.setBoxTitle(gameBox3.Name);
        boxMenu.setCoinText(gameBox3.MinCoins + " - " + gameBox3.MaxCoins);
        boxMenu.setGemText(gameBox3.MinGems + " - " + gameBox3.MaxGems);
        //boxMenu.setTankText();
        //boxMenu.setSkillText();  Kartlar eklenince gelecek
    }

    void timerFinished()
    {
        boxMenu.setButtonInteractable(true);
        boxMenu.setButtonText("OPEN");
    }

    void countDown()
    {
        boxMenu.setButtonText(MenuManager_Time.Format(gameBox3.RemainingTime));
    }

    void startOpeningGameBox3()
    {
        boxMenu.setButtonInteractable(true);
        boxMenu.setButtonText("START");
    }

    //Animasyonlu açılış menüsü tasarlayana kadar böyle kalacak
    //public void onClickOpenFreeBox()
    public override void onClickBoxMenuButton()
    {
        if (gameBox3.State == BoxState.Opened)
        {
            gameBox3.RestartRemainingTime();
            gameBox3.State = BoxState.Waiting;

            boxMenu.setCoinText(gameBox3.Coins.ToString());
            boxMenu.setGemText(gameBox3.Gems.ToString());

            //boxMenu.setTankText();
            //boxMenu.setSkillText();  Kartlar eklenince gelecek

            MM_Master.CallEventRestartGameBox3();
            //boxMenu.setButtonInteractable(false);

            //Bu değerler kalıcı olarak kaydedilecek 
        }
        else if (gameBox3.State == BoxState.Waiting)
        {
            boxMenu.setCoinText(gameBox3.Coins.ToString());
            boxMenu.setGemText(gameBox3.Gems.ToString());

            gameBox3.State = BoxState.Opening;
            gameBox3.RestartRemainingTime();

            MM_Master.CallEventUpdateGameBox3();
        }
    }
}
