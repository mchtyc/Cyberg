using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Enemy : MonoBehaviour
{
    public Transform enemyContainer;
    public EnemyWaves waves;
    public Transform[] spawnPositions;

    GameManager_Master GM_Master;
    int waveCount;

    void OnEnable()
    {
        GM_Master = GetComponent<GameManager_Master>();
        waveCount = waves.Count;
        GM_Master.EventStartNewWave += enemyBorn;
    }

    void OnDisable()
    {
        GM_Master.EventStartNewWave -= enemyBorn;
    }

    void enemyBorn()
    {
        foreach (Transform t in spawnPositions)
        {
            Instantiate(waves.EnemyType, t.position, Quaternion.identity, enemyContainer);
        }

        waveCount--;

        if (waveCount <= 0)
        {
            GM_Master.CallEventWavesFinished();
        }
    }
}
