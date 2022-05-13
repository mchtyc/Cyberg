using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Motor : MonoBehaviour
{
    public EnemyStats E_Stats;

    Vector3 target, dir;
    float dirChangeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeTarget());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir.normalized * Time.deltaTime * E_Stats.speed.Value;
    }

    IEnumerator changeTarget()
    {
        for (int i = 0; i < 1;)
        {
            change();
            yield return new WaitForSeconds(dirChangeTime);
        }
    }

    void change()
    {
        target = new Vector3(Random.Range(-10f, 10f), transform.position.y, Random.Range(-10f, 10f));
        dir = target - transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        change();
    }
}
