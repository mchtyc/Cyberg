using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    public PlayerStats P_Stats;

    Player_Master P_Master;
    string team;
    float recoveryInterval = 1f;


    public float timePastBeforeRecovery;

    void OnEnable()
    {
        P_Master = GetComponent<Player_Master>();

        P_Stats.currentHP.Set(P_Stats.maxHP.Value);
        team = GameManager_References.friendlyTag;
    }

    void startRecoverCountdown()
    {
        StopAllCoroutines();
        StartCoroutine(countAndRecover());
    }

    IEnumerator countAndRecover() {
        
        yield return new WaitForSeconds(timePastBeforeRecovery);

        while (true)
        {
            P_Stats.currentHP.Change(P_Stats.heal.Value, false);
            
            if (P_Stats.currentHP.Value > P_Stats.maxHP.Value)
            {
                P_Stats.currentHP.Set(P_Stats.maxHP.Value);
                P_Master.CallEventHealthUIUpdate();
                StopAllCoroutines();
            }

            P_Master.CallEventHealthUIUpdate();

            yield return new WaitForSeconds(recoveryInterval);
        }
    }

    void TakeDamage(float damage)
    {
        float netDamage = damage - P_Stats.defense.Value;
        startRecoverCountdown();

        if (netDamage > 0)
        {
            P_Stats.currentHP.Change(-netDamage, false);

            if (P_Stats.currentHP.Value <= 0)
            {
                P_Master.CallEventHealthUIUpdate();
                Die();
            }
            
            P_Master.CallEventHealthUIUpdate();
        }
    }

    void Die()
    {
        // Şimdilik böyle, sonra gameover screen hazırlanacak
        //SceneManager.LoadScene((int)Scenes.Play); // PlaceHolder
        SceneManager.LoadScene((int)Scenes.Menu);
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
