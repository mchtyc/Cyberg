using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModifierOperation { add, remove };

public class GameManager_References : MonoBehaviour
{
    // GameObject Names
    public static string gameManagerName = "Managers";
    public static string bulletContainerName = "Bullets";

    // Tags
    public static string playerTag = "Player";
    public static string friendlyTag = "Friendly";
    public static string hostileTag = "Hostile";
    public static string healthCanvasTag = "Health Canvas";

    // Layers
    public static int enemyTowerLayer = 8;

    // Player Transform
    public static Transform player;

    // Some Variables
    public static float timeBetweenWaves = 15f;

    GameManager_Master GM_Master;
    void OnEnable()
    {
        GM_Master = GetComponent<GameManager_Master>();

        GM_Master.EventOnPlayerBorn += getPlayerReference;
    }

    void OnDisable()
    {
        GM_Master.EventOnPlayerBorn -= getPlayerReference;
    }

    void getPlayerReference(Transform _player)
    {
        player = _player;
    }
}
