using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_RemoveModifier : MonoBehaviour
{
    public static GameManager_RemoveModifier instance;

    private void Awake()
    {
        instance = this;
    }

    public void remove(StatModifier mod, float t, Stat stat)
    {

        StartCoroutine(removeRoutine(mod, t, stat));
    }

    IEnumerator removeRoutine(StatModifier mod, float t, Stat stat)
    {
        yield return new WaitForSeconds(t);
        stat.RemoveModifier(mod);

    }
}
