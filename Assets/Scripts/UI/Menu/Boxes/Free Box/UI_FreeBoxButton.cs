using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI_FreeBoxButton : MonoBehaviour
{
    public MenuManager_Master MM_Master;
    public GameObject BoxMenu;
    public BoxData freeBox;

    Text buttonText;
    

    void OnEnable()
    {
        buttonText = GetComponentInChildren<Text>();

        MM_Master.EventUpdateFreeBox += updateFreeBoxTimer;
        MM_Master.EventOpenFreeBox += changeFreeBoxButtonText;
    }

    void OnDisable()
    {
        MM_Master.EventUpdateFreeBox -= updateFreeBoxTimer;
        MM_Master.EventOpenFreeBox -= changeFreeBoxButtonText;
    }

    void updateFreeBoxTimer()
    {
        buttonText.text = freeBox.Name + "\n" + MenuManager_Time.Format(freeBox.RemainingTime);
    }

    void changeFreeBoxButtonText()
    {
        buttonText.text = freeBox.Name + "\nOPEN";
    }

    public void OnClickFreeBoxButton()
    {
        BoxMenu.SetActive(true);
        BoxMenu.GetComponent<UI_FreeBoxMenu>().enabled = true;
        MM_Master.CallEventMenuToggled();
    }
}
