using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : Bullet
{
    public EnemyStats E_Stats;
    public Vector3 Target;

    Vector3 dir;
    float lifeTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        damage = E_Stats.damage.Value;
        speed = E_Stats.bulletSpeed.Value;
        dir = Target - transform.position;
        
        StartCoroutine(naturalDie());
    }

    private IEnumerator naturalDie()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void Update()
    {
        //This type of bullet fire from enemy to constant direction
        transform.position += dir.normalized * Time.deltaTime * E_Stats.bulletSpeed.Value;
    }
}
