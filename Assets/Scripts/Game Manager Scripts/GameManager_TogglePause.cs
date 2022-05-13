using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_TogglePause : MonoBehaviour
{
    public GameManager_Master GM_Master;
    public float unPauseTime = 2f;

    private bool isPaused;

    void OnEnable()
    {
        GM_Master.EventGameOver += TogglePause;
        GM_Master.EventMenuToggle += TogglePause;
    }

    void OnDisable()
    {
        GM_Master.EventGameOver -= TogglePause;
        GM_Master.EventMenuToggle -= TogglePause;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            StartCoroutine(unPause());
            isPaused = !isPaused;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = !isPaused;
        }
    }

    IEnumerator unPause()
    {
        int step = 5;

        for (int i = 0; i < step; i++)
        {
            yield return new WaitForSecondsRealtime(unPauseTime / step); 
            Time.timeScale += 1f / (float)step;
        }
    }
}
