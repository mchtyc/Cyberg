using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BoxMenu : MonoBehaviour
{
    public Text boxTitle, coinText, gemText, tankText, skillText, buttonText;
    public Button button;
    public MenuManager_Master MM_Master;

    public void setButtonInteractable(bool b)
    {
        button.interactable = b;
    }

    public void setButtonText(string s)
    {
        buttonText.text = s;
    }

    public void setBoxTitle(string s)
    {
        boxTitle.text = s;
    }

    public void setCoinText(string s)
    {
        coinText.text = s;
    }

    public void setGemText(string s)
    {
        gemText.text = s;
    }

    public void setTankText(string s)
    {
        tankText.text = s;
    }

    public void setSkillText(string s)
    {
        skillText.text = s;
    }

    public void onClickBoxMenuCloseButton()
    {
        MM_Master.CallEventCloseBoxMenu();
        MM_Master.CallEventMenuToggled();
    }

    public void onClickBoxMenuButton()
    {
        foreach(BoxMenuBase boxMenu in GetComponents(typeof(BoxMenuBase)))
        {
            if (boxMenu.enabled)
            {
                boxMenu.onClickBoxMenuButton();
            }
        }
    }
}
