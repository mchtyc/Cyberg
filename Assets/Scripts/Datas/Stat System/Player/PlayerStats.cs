using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Stats", order = 53)]
public class PlayerStats : ScriptableObject
{
    public Stat maxHP;
    public Stat currentHP;
    public Stat heal;

    public Stat damage;
    public Stat defense;

    public Stat criticalChance;
    public Stat criticalDamage;

    public Stat experience;
    public Stat level;

    public Stat range;
    public Stat speed;
    public Stat fireRate;              // number of shots per second
    public Stat bulletSpeed;
}
