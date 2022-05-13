using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyBoxButton : MonoBehaviour
{
    public MenuManager_Master MM_Master;
    public GameObject BoxMenu;
    public BoxData keyBox;

    Text buttonText;

    void OnEnable()
    {
        buttonText = GetComponentInChildren<Text>();
        
        MM_Master.EventUpdateKeyBox += updateKeyCount;
        MM_Master.EventOpenKeyBox += changeKeyBoxButtonText;
    }

    void OnDisable()
    {
        MM_Master.EventUpdateKeyBox -= updateKeyCount;
        MM_Master.EventOpenKeyBox -= changeKeyBoxButtonText;
    }

    void updateKeyCount()
    {
        buttonText.text = "Key Box\n" + keyBox.CurrentCount + " / " + keyBox.MaxCount;
    }

    void changeKeyBoxButtonText()
    {
        buttonText.text = "Key Box\nOPEN";
    }

    public void onClickKeyBoxButton()
    {
        BoxMenu.SetActive(true);
        BoxMenu.GetComponent<UI_KeyBoxMenu>().enabled = true;
        MM_Master.CallEventMenuToggled();
    }
}
