using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SODeneme2 : MonoBehaviour
{
    public SO_SaveDeneme P_Stats;
    public Text text1, text2;
    string json;

    void Start()
    {
        text1.text = "" + P_Stats.denemeStat.Value;
        Debug.Log(P_Stats.denemeStat.Value);
        P_Stats.denemeStat.Change(11, false);
        Debug.Log(P_Stats.denemeStat.Value);
        text2.text = "" + P_Stats.denemeStat.Value;
    }

    public void chnageScene()
    {
        SceneManager.LoadScene(0);
    }
}
