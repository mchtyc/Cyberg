using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Player : MonoBehaviour
{
    public GameObject Player;
        
    // Start is called before the first frame update
    void OnEnable()
    {
        Transform player = Instantiate(Player).transform;
        GetComponent<GameManager_Master>().CallEventOnPlayerBorn(player);
    }
}
