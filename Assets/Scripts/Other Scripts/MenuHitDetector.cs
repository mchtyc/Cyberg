using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Şuan sadece bilgisayarda çalışıyor. Telefon için touch inputu da kabul etmeli
public class MenuHitDetector : MonoBehaviour
{
    public Transform Managers;

    // Normal raycasts do not work on UI elements, they require a special kind
    GraphicRaycaster raycaster;
    MenuManager_Master MM_Master;
    bool menuToggled;

    void OnEnable()
    {
        raycaster = GetComponent<GraphicRaycaster>();
        MM_Master = Managers.GetComponent<MenuManager_Master>();

        MM_Master.EventMenuToggled += MenuToggled;
    }

    void OnDisable()
    {
        MM_Master.EventMenuToggled += MenuToggled;
    }

    void Update()
    {
        if (menuToggled)
        {
            //Check if the left Mouse button is clicked
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Set up the new Pointer Event
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                pointerData.position = Input.mousePosition;
                raycaster.Raycast(pointerData, results);
                
                if (results.Count > 0)
                {
                    GameObject hitUI = results[0].gameObject;

                    if (hitUI.tag == MenuManager_References.menuTag)
                    {
                        hitUI.SetActive(false);
                        menuToggled = !menuToggled;
                        MM_Master.CallEventCloseBoxMenu();
                    }
                }
            }

            if (Input.touchCount > 0)
            {
                //Set up the new Pointer Event
                PointerEventData pointerData = new PointerEventData(EventSystem.current);
                List<RaycastResult> results = new List<RaycastResult>();

                //Raycast using the Graphics Raycaster and mouse click position
                pointerData.position = Input.GetTouch(0).position;
                raycaster.Raycast(pointerData, results);

                if (results.Count > 0)
                {
                    GameObject hitUI = results[0].gameObject;

                    if (hitUI.tag == MenuManager_References.menuTag)
                    {
                        hitUI.SetActive(false);
                        menuToggled = !menuToggled;
                    }
                }
            } 
        }
    }

    void MenuToggled()
    {
        menuToggled = !menuToggled;
    }
}