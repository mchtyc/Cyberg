using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameBox2Menu : BoxMenuBase
{
    public BoxData gameBox2;
    public MenuManager_Master MM_Master;

    UI_BoxMenu boxMenu;

    void OnEnable()
    {
        boxMenu = GetComponent<UI_BoxMenu>();

        MM_Master.EventUpdateGameBox2 += countDown;
        MM_Master.EventOpenGameBox2 += timerFinished;
        MM_Master.EventWaitingGameBox2 += startOpeningGameBox2;

        SetBoxMenuReferences();
    }

    void OnDisable()
    {
        MM_Master.EventUpdateGameBox2 -= countDown;
        MM_Master.EventOpenGameBox2 -= timerFinished;
        MM_Master.EventWaitingGameBox2 -= startOpeningGameBox2;
    }

    public void SetBoxMenuReferences()
    {
        if (gameBox2.State == BoxState.Opening)
        {
            boxMenu.setButtonInteractable(false);
            boxMenu.setButtonText(MenuManager_Time.Format(gameBox2.RemainingTime));
        }
        else if(gameBox2.State == BoxState.Opened)
        {
            boxMenu.setButtonInteractable(true);
            boxMenu.setButtonText("OPEN");
        }
        else if (gameBox2.State == BoxState.Waiting)
        {
            boxMenu.setButtonInteractable(true);
            boxMenu.setButtonText("START");
        }

        boxMenu.setBoxTitle(gameBox2.Name);
        boxMenu.setCoinText(gameBox2.MinCoins + " - " + gameBox2.MaxCoins);
        boxMenu.setGemText(gameBox2.MinGems + " - " + gameBox2.MaxGems);
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
        boxMenu.setButtonText(MenuManager_Time.Format(gameBox2.RemainingTime));
    }

    void startOpeningGameBox2()
    {
        boxMenu.setButtonInteractable(true);
        boxMenu.setButtonText("START");
    }

    //Animasyonlu açılış menüsü tasarlayana kadar böyle kalacak
    //public void onClickOpenFreeBox()
    public override void onClickBoxMenuButton()
    {
        if (gameBox2.State == BoxState.Opened)
        {
            gameBox2.RestartRemainingTime();
            gameBox2.State = BoxState.Waiting;

            boxMenu.setCoinText(gameBox2.Coins.ToString());
            boxMenu.setGemText(gameBox2.Gems.ToString());

            //boxMenu.setTankText();
            //boxMenu.setSkillText();  Kartlar eklenince gelecek

            MM_Master.CallEventRestartGameBox2();
            //boxMenu.setButtonInteractable(false);

            //Bu değerler kalıcı olarak kaydedilecek 
        }
        else if (gameBox2.State == BoxState.Waiting)
        {
            boxMenu.setCoinText(gameBox2.Coins.ToString());
            boxMenu.setGemText(gameBox2.Gems.ToString());

            gameBox2.State = BoxState.Opening;
            gameBox2.RestartRemainingTime();

            MM_Master.CallEventUpdateGameBox2();
        }
    }
}
