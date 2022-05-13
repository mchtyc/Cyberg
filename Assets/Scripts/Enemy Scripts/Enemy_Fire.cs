using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fire : MonoBehaviour
{
    public GameObject Bullet01Pre;
    public EnemyStats E_Stats;

    Transform BulletContainer;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        BulletContainer = GameObject.Find("Bullets").transform;
        StartCoroutine(fire());
    }
    
    private IEnumerator fire() {

        yield return new WaitForSeconds(3f);

        while (true)
        {
            for (float x = -3f; x < 5; x += 6f)
            {
                target = transform.position + new Vector3(x, 0f, 0f);
                bulletIns(target);

                target = transform.position + new Vector3(0f, 0f, x);
                bulletIns(target);
            }

            yield return new WaitForSeconds(1f / E_Stats.fireRate.Value);
        }
    }

    private void bulletIns(Vector3 t)
    {
        Enemy_Bullet bullet = Instantiate(Bullet01Pre, t + (transform.position - t).normalized, Quaternion.identity, BulletContainer).GetComponent<Enemy_Bullet>();
        bullet.Target = t;
        bullet.Owner = gameObject.transform;
    }
}
