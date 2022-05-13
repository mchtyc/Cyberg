using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AdBoxButton : MonoBehaviour
{
    public MenuManager_Master MM_Master;
    public GameObject BoxMenu;
    public BoxData adBox;

    Text buttonText;

    void OnEnable()
    {
        buttonText = GetComponentInChildren<Text>();
        
        MM_Master.EventUpdateAdBox += updateAdBoxWatched;
        MM_Master.EventOpenAdBox += changeAdBoxButtonText;
    }

    void OnDisable()
    {
        MM_Master.EventUpdateAdBox -= updateAdBoxWatched;
        MM_Master.EventOpenAdBox -= changeAdBoxButtonText;
    }

    void updateAdBoxWatched()
    {
        buttonText.text = "Ad Box\n" + adBox.CurrentCount + " / " + adBox.MaxCount;
    }

    void changeAdBoxButtonText()
    {
        buttonText.text = "Ad Box\nOPEN";
    }

    public void onClickAdBoxButton()
    {
        BoxMenu.SetActive(true);
        BoxMenu.GetComponent<UI_AdBoxMenu>().enabled = true;
        MM_Master.CallEventMenuToggled();
    }
}
