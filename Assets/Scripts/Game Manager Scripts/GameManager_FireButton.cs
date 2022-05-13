using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_FireButton : MonoBehaviour
{
    GameManager_Master GM_Master;

    void OnEnable()
    {
        GM_Master = GetComponent<GameManager_Master>();
    }

    public void fireDown()
    {
        GM_Master.CallEventFireButtonHold(true);
    }

    public void fireUp()
    {
        GM_Master.CallEventFireButtonHold(false);
    }
}
