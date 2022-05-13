using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FreeBoxMenu : BoxMenuBase
{
    public BoxData freeBox;
    public MenuManager_Master MM_Master;

    UI_BoxMenu boxMenu;

    void OnEnable()
    {
        boxMenu = GetComponent<UI_BoxMenu>();

        MM_Master.EventUpdateFreeBox += countDown;
        MM_Master.EventOpenFreeBox += timerFinished;

        SetBoxMenuReferences();
    }

    void OnDisable()
    {
        MM_Master.EventUpdateFreeBox -= countDown;
        MM_Master.EventOpenFreeBox -= timerFinished;
    }

    public void SetBoxMenuReferences()
    {
        if (freeBox.State == BoxState.Opening)
        {
            boxMenu.setButtonInteractable(false);
            boxMenu.setButtonText(MenuManager_Time.Format(freeBox.RemainingTime));
        }
        else
        {
            boxMenu.setButtonInteractable(true);
            boxMenu.setButtonText("OPEN");
        }

        boxMenu.setBoxTitle(freeBox.Name);
        boxMenu.setCoinText(freeBox.MinCoins + " - " + freeBox.MaxCoins);
        boxMenu.setGemText(freeBox.MinGems + " - " + freeBox.MaxGems);
        //boxMenu.setTankText();
        //boxMenu.setSkillText();  Kartlar eklenince gelecek
    }

    public void timerFinished()
    {
        boxMenu.setButtonInteractable(true);
        boxMenu.setButtonText("OPEN");
    }

    public void countDown()
    {
        boxMenu.setButtonText(MenuManager_Time.Format(freeBox.RemainingTime));
    }

    //Animasyonlu açılış menüsü tasarlayana kadar böyle kalacak
    //public void onClickOpenFreeBox()
    public override void onClickBoxMenuButton()
    {
        freeBox.RestartRemainingTime();
        freeBox.State = BoxState.Opening;

        boxMenu.setCoinText(freeBox.Coins.ToString());
        boxMenu.setGemText(freeBox.Gems.ToString());

        //boxMenu.setTankText();
        //boxMenu.setSkillText();  Kartlar eklenince gelecek

        MM_Master.CallEventRestartFreeBox();
        boxMenu.setButtonInteractable(false);

        //Bu değerler kalıcı olarak kaydedilecek
    }
}
