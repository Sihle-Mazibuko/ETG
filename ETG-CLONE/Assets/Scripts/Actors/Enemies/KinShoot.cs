using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinShoot : MonoBehaviour
{
    public GameObject Bullet;
    
    public GameObject Enemy;

    public GameObject BulletSpawn1;
    public GameObject BulletSpawn2;
    public GameObject BulletSpawn3;

    // Start is called before the first frame update
    void Start()
    {
        if(Enemy.name == "Bullet Kin")
        {
            StartCoroutine(Shoot());
        }
        if(Enemy.name == "Shotgun Kin")
        {
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Shoot());
        Instantiate(Bullet, BulletSpawn1.transform.position, BulletSpawn1.transform.rotation);
        
    }

    public IEnumerator ShotShoot()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(ShotShoot());
        Instantiate(Bullet, BulletSpawn1.transform.position, BulletSpawn1.transform.rotation);
        Instantiate(Bullet, BulletSpawn2.transform.position, BulletSpawn2.transform.rotation);
        Instantiate(Bullet, BulletSpawn3.transform.position, BulletSpawn3.transform.rotation);

    }
}
