using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_WaveCounter : MonoBehaviour
{
    GameManager_Master GM_Master;

    float waveTime;
    bool isWavesFinished;

    void OnEnable()
    {
        GM_Master = GetComponent<GameManager_Master>();
        waveTime = GameManager_References.timeBetweenWaves;

        GM_Master.EventWavesFinished += isFinished;
        StartCoroutine(waveTimer());
    }

    void OnDisable()
    {
        GM_Master.EventWavesFinished -= isFinished;
    }

    IEnumerator waveTimer()
    {
        yield return new WaitForSeconds(2f);
        
        while (!isWavesFinished)
        {
            GM_Master.CallEventStartNewWave();

            yield return new WaitForSeconds(waveTime); 
        }
    }

    void isFinished()
    {
        isWavesFinished = true;
    }
}
