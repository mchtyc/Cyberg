using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_KeyBoxMenu : BoxMenuBase
{
    public BoxData keyBox;
    public MenuManager_Master MM_Master;

    UI_BoxMenu boxMenu;

    void OnEnable()
    {
        boxMenu = GetComponent<UI_BoxMenu>();

        MM_Master.EventUpdateKeyBox += keyAquired;
        MM_Master.EventOpenKeyBox += keyBoxReady;

        SetBoxMenuReferences();
    }

    void OnDisable()
    {
        MM_Master.EventUpdateKeyBox -= keyAquired;
        MM_Master.EventOpenKeyBox -= keyBoxReady;
    }

    public void SetBoxMenuReferences()
    {
        if (keyBox.State == BoxState.Opening)
        {
            boxMenu.setButtonInteractable(false);
            boxMenu.setButtonText(keyBox.CurrentCount + " / " + keyBox.MaxCount);
        }
        else
        {
            boxMenu.setButtonInteractable(true);
            boxMenu.setButtonText("OPEN");
        }

        boxMenu.setBoxTitle(keyBox.Name);
        boxMenu.setCoinText(keyBox.MinCoins + " - " + keyBox.MaxCoins);
        boxMenu.setGemText(keyBox.MinGems + " - " + keyBox.MaxGems);
        //boxMenu.setTankText();
        //boxMenu.setSkillText();  Kartlar eklenince gelecek
    }

    public void keyBoxReady()
    {
        boxMenu.setButtonInteractable(true);
        boxMenu.setButtonText("OPEN");
    }

    public void keyAquired()
    {
        boxMenu.setButtonText(keyBox.CurrentCount + " / " + keyBox.MaxCount);
    }

    //Animasyonlu açılış menüsü tasarlayana kadar böyle kalacak
    public override void onClickBoxMenuButton()
    {
        keyBox.RestartCurrentCount();
        keyBox.createBox();
        keyBox.State = BoxState.Opening;

        boxMenu.setCoinText(keyBox.Coins.ToString());
        boxMenu.setGemText(keyBox.Gems.ToString());

        //boxMenu.setTankText();
        //boxMenu.setSkillText();  Kartlar eklenince gelecek

        MM_Master.CallEventRestartKeyBox();
        boxMenu.setButtonInteractable(false);

        //Bu değerler kalıcı olarak kaydedilecek
    }
}
