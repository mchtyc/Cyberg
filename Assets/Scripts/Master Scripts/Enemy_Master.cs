using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Master : MonoBehaviour
{
    public delegate void EnemyEventHandler();
    public delegate void EnemyEventHealthHandler(float currentHP);

    public event EnemyEventHealthHandler EventHealthUIUpdate;
    public event EnemyEventHandler EventOnEnemyDie;

    public void CallEventHealthUIUpdate(float currentHP)
    {
        if (EventHealthUIUpdate != null)
        {
            EventHealthUIUpdate(currentHP);
        }
    }

    public void CallEventEventOnEnemyDie()
    {
        if (EventOnEnemyDie != null)
        {
            EventOnEnemyDie();
        }
    }
}
