using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager_LoadPlayScene : MonoBehaviour
{
    public PlayerStats P_Stats;
    public TankStats T_Stats;   //Tanklar arttıkça seçilen tanka göre statlar arasında geçiş yapılmalı

    public void openPlayScene()
    {
        loadPlayerStats();
        SceneManager.LoadScene((int)Scenes.Play);
    }

    void loadPlayerStats()
    {
        P_Stats.maxHP = T_Stats.HP;
        P_Stats.heal = T_Stats.heal;
        P_Stats.damage = T_Stats.damage;
        P_Stats.defense = T_Stats.defense;
        P_Stats.criticalChance = T_Stats.criticalChance;
        P_Stats.criticalDamage = T_Stats.criticalDamage;
        P_Stats.range = T_Stats.range;
        P_Stats.speed = T_Stats.speed;
        P_Stats.bulletSpeed = T_Stats.bulletSpeed;
        P_Stats.fireRate = T_Stats.fireRate;
    }
}
