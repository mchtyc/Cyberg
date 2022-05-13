using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameBox1Button : MonoBehaviour
{
    public MenuManager_Master MM_Master;
    public GameObject BoxMenu;
    public BoxData gameBox1;

    Text buttonText;


    void OnEnable()
    {
        buttonText = GetComponentInChildren<Text>();

        MM_Master.EventUpdateGameBox1 += updateGameBox1Timer;
        MM_Master.EventOpenGameBox1 += changeToOpenGameBox1ButtonText;
        MM_Master.EventWaitingGameBox1 += changeToStartGameBox1ButtonText;
    }

    void OnDisable()
    {
        MM_Master.EventUpdateGameBox1 -= updateGameBox1Timer;
        MM_Master.EventOpenGameBox1 -= changeToOpenGameBox1ButtonText;
        MM_Master.EventWaitingGameBox1 -= changeToStartGameBox1ButtonText;
    }

    void updateGameBox1Timer()
    {
        buttonText.text = gameBox1.Name + "\n" + MenuManager_Time.Format(gameBox1.RemainingTime);
    }

    void changeToOpenGameBox1ButtonText()
    {
        buttonText.text = gameBox1.Name + "\nOPEN";
    }

    void changeToStartGameBox1ButtonText()
    {
        buttonText.text = gameBox1.Name + "\nSTART";
    }

    public void OnClickGameBox1Button()
    {
        BoxMenu.SetActive(true);
        BoxMenu.GetComponent<UI_GameBox1Menu>().enabled = true;
        MM_Master.CallEventMenuToggled();
    }
}
