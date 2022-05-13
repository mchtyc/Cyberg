using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class remove : MonoBehaviour
{
    public static remove instance;

    private void Awake()
    {
        instance = this;
    }

    public void removeModifier(StatModifierSample mod, float t, CharacterStatSample cs)
    {
        
        StartCoroutine(removeM(mod, t, cs));
    }
    
    IEnumerator removeM(StatModifierSample mod, float t, CharacterStatSample cs)
    {
        yield return new WaitForSeconds(t);
        cs.RemoveModifier(mod);
        Debug.Log(cs.Value);
        
    }
}
