using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public EnemyStats E_Stats;

    Enemy_Master E_Master;
    string team;
    float currentHP;
    
    void OnEnable()
    {
        E_Master = GetComponent<Enemy_Master>();
        currentHP = E_Stats.maxHP.Value;

        team = GameManager_References.hostileTag;
    }

    void OnDisable()
    {
    }

    void TakeDamage(float damage)
    {
        float netDamage = damage - E_Stats.defense.Value;

        if (netDamage > 0)
        {
            currentHP -= netDamage;

            if (currentHP <= 0)
            {
                E_Master.CallEventHealthUIUpdate(currentHP);
                Die();
            }

            E_Master.CallEventHealthUIUpdate(currentHP);
        }
    }

    void Die()
    {
        E_Master.CallEventEventOnEnemyDie();
        Destroy(gameObject);
        //if (transform.localScale.x > 3f)
        //{
        //    transform.position += new Vector3(1f, 0f, 1f);
        //    transform.localScale = transform.localScale - Vector3.one;
        //    currentHP.Value = maxHP.Value;

        //    Instantiate(gameObject, transform.parent);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            if (!other.CompareTag(team))
            {
                TakeDamage(bullet.damage);

                Destroy(other.gameObject);
            }
        }
    }
}
