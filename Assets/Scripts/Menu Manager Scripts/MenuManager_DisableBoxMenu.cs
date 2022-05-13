using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager_DisableBoxMenu : MonoBehaviour
{
    MenuManager_Master MM_Master;

    public Transform BoxMenu;
    public BoxMenuBase[] BoxMenu_UIs;
    
    void OnEnable()
    {
        MM_Master = GetComponent<MenuManager_Master>();

        MM_Master.EventCloseBoxMenu += disableBoxes;

        disableBoxes();
    }

    void OnDisable()
    {
        MM_Master.EventCloseBoxMenu -= disableBoxes;
    }

    void disableBoxes()
    {
        BoxMenu.gameObject.SetActive(false);

        foreach (BoxMenuBase boxMenu in BoxMenu.GetComponents(typeof(BoxMenuBase)))
        {
            boxMenu.enabled = false;
        }
    }
}
