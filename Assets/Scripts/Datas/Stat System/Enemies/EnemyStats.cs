using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", order = 54)]
public class EnemyStats : ScriptableObject
{
    public Stat maxHP;

    public Stat defense;
    public Stat damage;

    public Stat fireRate;
    public Stat speed;
    public Stat bulletSpeed;
}
