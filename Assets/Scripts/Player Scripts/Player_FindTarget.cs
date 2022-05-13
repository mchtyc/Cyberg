using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_FindTarget : MonoBehaviour
{
    public LayerMask enemyLayer;
    public PlayerStats P_Stats;

    Player_Master P_Master;
    Transform closestEnemy;
    float enemySearchInterval = 1f;
    bool checkIfTargetNull;

    void OnEnable()
    {
        P_Master = GetComponent<Player_Master>();
        StartCoroutine(findTarget());
    }

    void Update()
    {
        if (checkIfTargetNull && closestEnemy == null)
        {
            StopAllCoroutines();
            StartCoroutine(findTarget());
            checkIfTargetNull = false;
        }
    }

    IEnumerator findTarget()
    {
        while (true)
        {
            float distance = Mathf.Infinity;
            closestEnemy = null;

            foreach (Collider c in Physics.OverlapSphere(transform.position, P_Stats.range.Value, enemyLayer))
            { 
                Transform t = c.gameObject.transform;
                float d = Vector3.Distance(t.position, transform.position);
                if (d < distance)
                {
                    distance = d;
                    closestEnemy = t;
                }
            }

            P_Master.CallEventFindTarget(closestEnemy);
            
            if (closestEnemy != null)
            {
                checkIfTargetNull = true; 
            }

            yield return new WaitForSeconds(enemySearchInterval); 
        }
    }
}
