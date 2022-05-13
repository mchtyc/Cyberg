using UnityEngine;
using System.Collections;

public class Player_Bullet : Bullet
{
    public PlayerStats P_Stats;
    public GameObject muzzle, cartoon;

    Vector3 startingPoint;
        
    void Start()
    {        
        if (Random.Range(1, 101) <= P_Stats.criticalChance.Value*100)
        {
            damage = P_Stats.criticalDamage.Value;
        }
        else
        {
            damage = P_Stats.damage.Value;
        }

        startingPoint = transform.position;

        Instantiate(muzzle, transform.position, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += transform.forward * Time.deltaTime * P_Stats.bulletSpeed.Value;

        if (Vector3.Distance(transform.position, startingPoint) >= P_Stats.range.Value)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(cartoon, transform.position, Quaternion.identity);
        }
    }
}
