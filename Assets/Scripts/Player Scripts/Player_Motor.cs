using System;
using System.Collections;
using UnityEngine;

public class Player_Motor : MonoBehaviour
{
    public PlayerStats P_Stats;

    Vector3 dir;
    float vertical, horizontal, maxDistance = 100f, minDistance = 10f;
    Rigidbody Body;
    Vector2 touchPos = Vector2.zero;

    void Start()
    {
        Body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            TouchInputForAndroid();
        }

        if (Input.anyKey) {
            MoveAndTurn();
        }
        else
        {
            Body.velocity = Vector3.zero;
        }
    }

    private void MoveAndTurn()
    {
#if UNITY_EDITOR

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
#endif
        Move();
        Turn();

    }

    private void Turn()
    {
        dir = new Vector3(horizontal, 0f, vertical).normalized;
       
        if (dir != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20f);
            transform.rotation = lookRotation;
        }
    }
     
    private void Move()
    {
        transform.position += new Vector3(horizontal, 0f, vertical) * Time.deltaTime * P_Stats.speed.Value;
    }

    private void TouchInputForAndroid()
    {
#if UNITY_ANDROID

        foreach (Touch t in Input.touches)
        {
            if (t.position.x < Screen.width * 0.7f && t.position.y < Screen.height * 0.7f) // 0.7 yaklaşık olarak sağdaki tuşların sol tarafı
            {
                if (t.phase == TouchPhase.Began)
                {
                    touchPos = t.position;
                }
                else if (t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary)
                {
                    float v = t.position.y - touchPos.y;
                    float h = t.position.x - touchPos.x;

                    if (v > minDistance || h > minDistance)
                    {
                        vertical = v;
                        horizontal = h;

                        vertical = Mathf.Clamp(vertical, -maxDistance, maxDistance) / maxDistance;
                        horizontal = Mathf.Clamp(horizontal, -maxDistance, maxDistance) / maxDistance; 
                    }
                }
                else
                {
                    vertical = horizontal = 0;
                }
            }
        }
#endif
    }
}
