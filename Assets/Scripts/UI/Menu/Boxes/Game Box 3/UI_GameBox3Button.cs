using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameBox3Button : MonoBehaviour
{
    public MenuManager_Master MM_Master;
    public GameObject BoxMenu;
    public BoxData gameBox3;

    Text buttonText;


    void OnEnable()
    {
        buttonText = GetComponentInChildren<Text>();

        MM_Master.EventUpdateGameBox3 += updateGameBox3Timer;
        MM_Master.EventOpenGameBox3 += changeToOpenGameBox3ButtonText;
        MM_Master.EventWaitingGameBox3 += changeToStartGameBox3ButtonText;
    }

    void OnDisable()
    {
        MM_Master.EventUpdateGameBox3 -= updateGameBox3Timer;
        MM_Master.EventOpenGameBox3 -= changeToOpenGameBox3ButtonText;
        MM_Master.EventWaitingGameBox3 -= changeToStartGameBox3ButtonText;
    }

    void updateGameBox3Timer()
    {
        buttonText.text = gameBox3.Name + "\n" + MenuManager_Time.Format(gameBox3.RemainingTime);
    }

    void changeToOpenGameBox3ButtonText()
    {
        buttonText.text = gameBox3.Name + "\nOPEN";
    }

    void changeToStartGameBox3ButtonText()
    {
        buttonText.text = gameBox3.Name + "\nSTART";
    }

    public void OnClickGameBox3Button()
    {
        BoxMenu.SetActive(true);
        BoxMenu.GetComponent<UI_GameBox3Menu>().enabled = true;
        MM_Master.CallEventMenuToggled();
    }
}
