using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Level  Waves", menuName = "Enemy Waves", order = 51)]
public class EnemyWaves : ScriptableObject
{
    public int count;
    public GameObject enemyType;

    public int Count
    {
        get { return count; }
    }

    public GameObject EnemyType
    {
        get { return enemyType; }
    }
}
