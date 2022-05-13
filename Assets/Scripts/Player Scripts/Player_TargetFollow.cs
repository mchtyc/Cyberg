using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TargetFollow : MonoBehaviour
{
    Player_Master P_Master;
    Vector3 dir;
    Transform target;

    void OnEnable()
    {
        P_Master = GetComponentInParent<Player_Master>();
        P_Master.EventFindTarget += getTarget;
    }

    void OnDisable()
    {
        P_Master.EventFindTarget -= getTarget;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lookRotation;

        if (target != null)
        {
            dir = target.position - transform.position;

            lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20f);
        }
        else
        {
            lookRotation = Quaternion.Euler(0f, 0f, 0f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, lookRotation, Time.deltaTime * 20f);
        }
    }

    void getTarget(Transform t)
    {
        target = t;
    }
}
