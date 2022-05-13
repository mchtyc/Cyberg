using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AdBoxMenu : BoxMenuBase
{
    public BoxData adBox;
    public MenuManager_Master MM_Master;

    UI_BoxMenu boxMenu;

    void OnEnable()
    {
        boxMenu = GetComponent<UI_BoxMenu>();

        MM_Master.EventUpdateAdBox += adWatched;
        MM_Master.EventOpenAdBox += adBoxReady;

        SetBoxMenuReferences();
    }

    void OnDisable()
    {
        MM_Master.EventUpdateAdBox -= adWatched;
        MM_Master.EventOpenAdBox -= adBoxReady;
    }

    public void SetBoxMenuReferences()
    {
        if (adBox.State == BoxState.Opening)
        {
            boxMenu.setButtonInteractable(false);
            boxMenu.setButtonText(adBox.CurrentCount + " / " + adBox.MaxCount);
        }
        else
        {
            boxMenu.setButtonInteractable(true);
            boxMenu.setButtonText("OPEN");
        }

        boxMenu.setBoxTitle(adBox.Name);
        boxMenu.setCoinText(adBox.Coins.ToString());
        boxMenu.setGemText(adBox.Gems.ToString());
        //boxMenu.setTankText();
        //boxMenu.setSkillText();  Kartlar eklenince gelecek
    }

    public void adBoxReady()
    {
        boxMenu.setButtonInteractable(true);
        boxMenu.setButtonText("OPEN");
    }

    public void adWatched()
    {
        boxMenu.setButtonText(adBox.CurrentCount + " / " + adBox.MaxCount);
    }

    //Animasyonlu açılış menüsü tasarlayana kadar böyle kalacak
    //public void onClickOpenAdBox()
    public override void onClickBoxMenuButton()
    {
    
        adBox.RestartCurrentCount();
        adBox.State = BoxState.Opening;

        boxMenu.setCoinText(adBox.Coins.ToString());
        boxMenu.setGemText(adBox.Gems.ToString());

        //boxMenu.setTankText();
        //boxMenu.setSkillText();  Kartlar eklenince gelecek

        MM_Master.CallEventRestartAdBox();
        boxMenu.setButtonInteractable(false);

        //Bu değerler kalıcı olarak kaydedilecek
    }
}
