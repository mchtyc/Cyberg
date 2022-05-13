using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MissionBoxButton : MonoBehaviour
{
    public MenuManager_Master MM_Master;
    public GameObject BoxMenu;
    public BoxData missionBox;

    Text buttonText;

    void OnEnable()
    {
        buttonText = GetComponentInChildren<Text>();

        MM_Master.EventUpdateMissionBox += updateMissionCount;
        MM_Master.EventOpenMissionBox += changeMissionBoxButtonText;
    }

    void OnDisable()
    {
        MM_Master.EventUpdateMissionBox -= updateMissionCount;
        MM_Master.EventOpenMissionBox -= changeMissionBoxButtonText;
    }

    void updateMissionCount()
    {
        buttonText.text = "Mission Box\n" + missionBox.CurrentCount + " / " + missionBox.MaxCount;
    }

    void changeMissionBoxButtonText()
    {
        buttonText.text = "Mission Box\nOPEN";
    }

    public void onClickMissionBoxButton()
    {
        BoxMenu.SetActive(true);
        BoxMenu.GetComponent<UI_MissionBoxMenu>().enabled = true;
        MM_Master.CallEventMenuToggled();
    }
}
