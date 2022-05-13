using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Vector3 offset;
    float clampMin, clampMax;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag(GameManager_References.playerTag).transform;
        offset = target.position - transform.position;

        clampMin = -40f;
        clampMax = 7f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        CameraMove();
    }

    void CameraMove()
    {
        //transform.position = new Vector3(target.position.x - offset.x, transform.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp((target.position.x - offset.x), clampMin, clampMax), transform.position.y, transform.position.z);
    }
}
