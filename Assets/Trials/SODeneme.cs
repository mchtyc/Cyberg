using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class SODeneme : MonoBehaviour
{
    public SO_SaveDeneme saveStats;
    public Text text1, text2;

    private void Awake()
    {
        saveStats.denemeStat = LoadData();
    }

    void Start()
    {
        text1.text = "" + saveStats.denemeStat.Value;
        Debug.Log(saveStats.denemeStat.Value);
        saveStats.denemeStat.Change(11, false);
        Debug.Log(saveStats.denemeStat.Value);
        text2.text = "" + saveStats.denemeStat.Value;
    }

    private void OnDisable()
    {
        SaveData();
    }

    public void chnageScene()
    {
        SceneManager.LoadScene(1);
    }

    void SaveData()
    {
        string json = JsonUtility.ToJson(saveStats);
        File.WriteAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "sData.txt", json);
    }

    Stat LoadData()
    {
        SO_SaveDeneme data = null;
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "sData.txt"))
        {
            data = ScriptableObject.CreateInstance<SO_SaveDeneme>();
            string json = File.ReadAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "sData.txt");
            JsonUtility.FromJsonOverwrite(json, data);
        }
        else
        {
            data = Resources.Load<SO_SaveDeneme>("saveData");
        }
        return data.denemeStat;
    }
}
