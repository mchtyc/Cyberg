using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank Stats", order = 56)]
public class TankStats : ScriptableObject
{
    public Stat HP;
    public Stat damage;
    public Stat defense;
    public Stat speed;
    public Stat heal;

    public Stat criticalChance;
    public Stat criticalDamage;

    public Stat level;

    public Stat range;
    public Stat bulletSpeed;
    public Stat fireRate;

    // Elde edilen ve level atlamak için gereken kart sayıları eklenecek
}
