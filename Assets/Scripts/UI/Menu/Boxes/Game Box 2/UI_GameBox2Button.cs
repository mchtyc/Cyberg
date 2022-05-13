using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameBox2Button : MonoBehaviour
{
    public MenuManager_Master MM_Master;
    public GameObject BoxMenu;
    public BoxData gameBox2;

    Text buttonText;


    void OnEnable()
    {
        buttonText = GetComponentInChildren<Text>();

        MM_Master.EventUpdateGameBox2 += updateGameBox2Timer;
        MM_Master.EventOpenGameBox2 += changeToOpenGameBox2ButtonText;
        MM_Master.EventWaitingGameBox2 += changeToStartGameBox2ButtonText;
    }

    void OnDisable()
    {
        MM_Master.EventUpdateGameBox2 -= updateGameBox2Timer;
        MM_Master.EventOpenGameBox2 -= changeToOpenGameBox2ButtonText;
        MM_Master.EventWaitingGameBox2 -= changeToStartGameBox2ButtonText;
    }

    void updateGameBox2Timer()
    {
        buttonText.text = gameBox2.Name + "\n" + MenuManager_Time.Format(gameBox2.RemainingTime);
    }

    void changeToOpenGameBox2ButtonText()
    {
        buttonText.text = gameBox2.Name + "\nOPEN";
    }

    void changeToStartGameBox2ButtonText()
    {
        buttonText.text = gameBox2.Name + "\nSTART";
    }

    public void OnClickGameBox2Button()
    {
        BoxMenu.SetActive(true);
        BoxMenu.GetComponent<UI_GameBox2Menu>().enabled = true;
        MM_Master.CallEventMenuToggled();
    }
}
