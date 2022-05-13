using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newScene : MonoBehaviour
{
    public allStats playerStats;
    public allStats enemyStats;
    StatModifierSample sMod;

    // Start is called before the first frame update
    void Start()
    {
        sMod = new StatModifierSample(10f, StatModTypeOld.Flat);
        //Debug.Log("PAttack: " + playerStats.playerAttack.Value);
        //Debug.Log("PHP    : " + playerStats.playerHP.Value);

        Debug.Log("EAttack: " + enemyStats.playerAttack.Value);
        //Debug.Log("EHP    : " + enemyStats.playerHP.Value);

        playerStats.playerAttack.AddModifier(sMod, 5f, playerStats.playerAttack);
        //playerStats.playerHP.AddModifier(sMod);
        //enemyStats.playerAttack.AddModifier(sMod);
        //enemyStats.playerHP.AddModifier(sMod);

        Debug.Log("Attack+: " + playerStats.playerAttack.Value);
        //Debug.Log("HP+    : " + playerStats.playerHP.Value);

        //Debug.Log("EAttack: " + enemyStats.playerAttack.Value);
        //Debug.Log("EHP    : " + enemyStats.playerHP.Value);


    }

    private void Update()
    {
        Debug.Log(playerStats.playerAttack.Value);
    }
}
