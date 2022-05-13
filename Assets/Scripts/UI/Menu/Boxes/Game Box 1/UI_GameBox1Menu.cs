using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameBox1Menu : BoxMenuBase
{
    public BoxData gameBox1;
    public MenuManager_Master MM_Master;

    UI_BoxMenu boxMenu;

    void OnEnable()
    {
        boxMenu = GetComponent<UI_BoxMenu>();

        MM_Master.EventUpdateGameBox1 += countDown;
        MM_Master.EventOpenGameBox1 += timerFinished;
        MM_Master.EventWaitingGameBox1 += startOpeningGameBox1;

        SetBoxMenuReferences();
    }

    void OnDisable()
    {
        MM_Master.EventUpdateGameBox1 -= countDown;
        MM_Master.EventOpenGameBox1 -= timerFinished;
        MM_Master.EventWaitingGameBox1 -= startOpeningGameBox1;
    }

    public void SetBoxMenuReferences()
    {
        if (gameBox1.State == BoxState.Opening)
        {
            boxMenu.setButtonInteractable(false);
            boxMenu.setButtonText(MenuManager_Time.Format(gameBox1.RemainingTime));
        }
        else if (gameBox1.State == BoxState.Opened)
        {
            boxMenu.setButtonInteractable(true);
            boxMenu.setButtonText("OPEN");
        }
        else if (gameBox1.State == BoxState.Waiting)
        {
            boxMenu.setButtonInteractable(true);
            boxMenu.setButtonText("START");
        }

        boxMenu.setBoxTitle(gameBox1.Name);
        boxMenu.setCoinText(gameBox1.MinCoins + " - " + gameBox1.MaxCoins);
        boxMenu.setGemText(gameBox1.MinGems + " - " + gameBox1.MaxGems);
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
        boxMenu.setButtonText(MenuManager_Time.Format(gameBox1.RemainingTime));
    }

    void startOpeningGameBox1()
    {
        boxMenu.setButtonInteractable(true);
        boxMenu.setButtonText("START");
    }

    //Animasyonlu açılış menüsü tasarlayana kadar böyle kalacak
    //public void onClickOpenFreeBox()
    public override void onClickBoxMenuButton()
    {
        if (gameBox1.State == BoxState.Opened)
        {
            gameBox1.RestartRemainingTime();
            gameBox1.State = BoxState.Waiting;

            boxMenu.setCoinText(gameBox1.Coins.ToString());
            boxMenu.setGemText(gameBox1.Gems.ToString());

            //boxMenu.setTankText();
            //boxMenu.setSkillText();  Kartlar eklenince gelecek

            MM_Master.CallEventRestartGameBox1();
            //boxMenu.setButtonInteractable(false);

            //Bu değerler kalıcı olarak kaydedilecek 
        }
        else if(gameBox1.State == BoxState.Waiting)
        {
            boxMenu.setCoinText(gameBox1.Coins.ToString());
            boxMenu.setGemText(gameBox1.Gems.ToString());

            gameBox1.State = BoxState.Opening;
            gameBox1.RestartRemainingTime();

            MM_Master.CallEventUpdateGameBox1();
        }
    }
}
