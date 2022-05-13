using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MissionBoxMenu : BoxMenuBase
{
    public BoxData missionBox;
    public MenuManager_Master MM_Master;

    UI_BoxMenu boxMenu;

    void OnEnable()
    {
        boxMenu = GetComponent<UI_BoxMenu>();

        MM_Master.EventUpdateMissionBox += missionCompleted;
        MM_Master.EventOpenMissionBox += missionBoxReady;

        SetBoxMenuReferences();
    }

    void OnDisable()
    {
        MM_Master.EventUpdateMissionBox -= missionCompleted;
        MM_Master.EventOpenMissionBox -= missionBoxReady;
    }

    public void SetBoxMenuReferences()
    {
        if (missionBox.State == BoxState.Opening)
        {
            boxMenu.setButtonInteractable(false);
            boxMenu.setButtonText(missionBox.CurrentCount + " / " + missionBox.MaxCount);
        }
        else
        {
            boxMenu.setButtonInteractable(true);
            boxMenu.setButtonText("OPEN");
        }

        boxMenu.setBoxTitle(missionBox.Name);
        boxMenu.setCoinText(missionBox.MinCoins + " - " + missionBox.MaxCoins);
        boxMenu.setGemText(missionBox.MinGems + " - " + missionBox.MaxGems);
        //boxMenu.setTankText();
        //boxMenu.setSkillText();  Kartlar eklenince gelecek
    }

    public void missionBoxReady()
    {
        boxMenu.setButtonInteractable(true);
        boxMenu.setButtonText("OPEN");
    }

    public void missionCompleted()
    {
        boxMenu.setButtonText(missionBox.CurrentCount + " / " + missionBox.MaxCount);
    }

    //Animasyonlu açılış menüsü tasarlayana kadar böyle kalacak
    public override void onClickBoxMenuButton()
    {
        missionBox.RestartCurrentCount();
        missionBox.State = BoxState.Opening;

        boxMenu.setCoinText(missionBox.Coins.ToString());
        boxMenu.setGemText(missionBox.Gems.ToString());

        //boxMenu.setTankText();
        //boxMenu.setSkillText();  Kartlar eklenince gelecek

        MM_Master.CallEventRestartMissionBox();
        boxMenu.setButtonInteractable(false);

        //Bu değerler kalıcı olarak kaydedilecek
    }
}
