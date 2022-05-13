using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    string url = "http://worldtimeapi.org/api/timezone/Etc/UTC";
    string timeData;
    double elapsedTime;

    private void Start()
    {
        StartCoroutine(getDate());
    }

    IEnumerator getDate()
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.isHttpError || www.isNetworkError)
        {
            Debug.LogWarning(www.error);
            pickDate();
        }
        else
        {
            timeData = www.downloadHandler.text;
            elapsedTime = Time.realtimeSinceStartup;
            Debug.Log(elapsedTime);
            pickDate();
        }
    }

    void pickDate()
    {
        //timeData = timeData.Remove(0, timeData.IndexOf("utc_datetime") + 15);
        //timeData = timeData.Remove(19);
        

        DateTime dateNow = Convert.ToDateTime(DateTime.Now);
        Debug.Log(dateNow);
        DateTime dateNow2 = dateNow.AddSeconds(-elapsedTime);
        
        DateTime dateOld = Convert.ToDateTime(timeData);
        Debug.Log(dateOld);
        if (dateOld == null)
        {
            Debug.Log("null");
        }
        TimeSpan diff = dateNow.Subtract(dateOld);
    }

    public void changeScene()
    {
        SceneManager.LoadScene(0);
    }
}
