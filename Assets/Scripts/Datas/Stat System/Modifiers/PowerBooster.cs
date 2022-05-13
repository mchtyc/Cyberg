using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBooster : MonoBehaviour
{
    //public StatModifier powerBoster;
    Player_Master P_Master;

    void OnEnable()
    {
        //powerBoster = new StatModifier(5f, StatModType.Flat, this);    //StatModifier oluşturma yöntemi eklenecek
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == GameManager_References.playerTag)
        {
            P_Master = other.gameObject.GetComponent<Player_Master>();
            P_Master.CallEventExperienceIncrease(43f);

            //P_Master.CallEventRangeModifier(powerBoster, ModifierOperation.add);
            //P_Master.CallEventStatChanged();
            //StartCoroutine(a());
            //Destroy(gameObject);
        }
    }

    IEnumerator a()
    {
        yield return new WaitForSeconds(3f);
        //P_Master.CallEventDamageModifier(powerBoster, ModifierOperation.remove);
        //P_Master.CallEventStatChanged();
        Destroy(gameObject);
    }
}
