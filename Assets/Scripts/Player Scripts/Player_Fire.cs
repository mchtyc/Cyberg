using UnityEngine;
using System.Collections;

public class Player_Fire : MonoBehaviour
{
    public GameObject BulletPre;
    public Transform ShotPoint, headSphere;
    public PlayerStats P_Stats;

    Transform BulletContainer;
    GameManager_Master GM_Master;
    float fireTime = 0f;

    //reloadTime tanklara göre değişik değerler alacak..!

    void OnEnable()
    {
        BulletContainer = GameObject.Find(GameManager_References.bulletContainerName).transform;
        GM_Master = GameObject.Find(GameManager_References.gameManagerName).GetComponent<GameManager_Master>();

        GM_Master.EventFireButtonHold += fire;
    }

    void OnDisable()
    {
        GM_Master.EventFireButtonHold -= fire;
    }

    void fire(bool isFire)
    {
        if (isFire)
        {
            StartCoroutine(fireBullet());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    // Zamanlama konusunda geliştirme gerekiyor gibi
    IEnumerator fireBullet()
    {
        float timeLapse = Time.time - fireTime;
        float rate = 1 / P_Stats.fireRate.Value;

        if (timeLapse < rate)
        {
            yield return new WaitForSeconds(rate - timeLapse);
        }

        while (true)
        {
            Player_Bullet bullet = Instantiate(BulletPre, ShotPoint.position, headSphere.rotation, BulletContainer).GetComponent<Player_Bullet>();
            bullet.Owner = gameObject.transform;
            
            fireTime = Time.time;
            yield return new WaitForSeconds(rate); 
        }
    }
}
