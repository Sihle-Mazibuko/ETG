using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinShoot : MonoBehaviour
{
    public GameObject Bullet;
   

    public float distanceBetweenObjects;



    public float timer = 1.5f;
    
    public GameObject Enemy;
    public GameObject Player;

    public GameObject BulletSpawn1;
    public GameObject BulletSpawn2;
    public GameObject BulletSpawn3;

    public bool Close;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PLAYER");
        if (Enemy.name == "Bullet Kin")
        {
            StartCoroutine(Shoot());
        }
        if(Enemy.name == "Bandana Kin")
        {
            Close = false;
            StartCoroutine(BandanaShoot());
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetweenObjects = Vector3.Distance(transform.position, Player.transform.position);
        Debug.DrawLine(transform.position, Player.transform.position, Color.green);

        if(distanceBetweenObjects <= 5)
        {
            Close = true;
        }
        else
        {
            Close = false;
        }
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timer);
        StartCoroutine(Shoot());
        Instantiate(Bullet, BulletSpawn1.transform.position, BulletSpawn1.transform.rotation);
        
    }

    public IEnumerator ShotShoot()
    {
        yield return new WaitForSeconds(timer);
        StartCoroutine(ShotShoot());
        Instantiate(Bullet, BulletSpawn1.transform.position, BulletSpawn1.transform.rotation);
        Instantiate(Bullet, BulletSpawn2.transform.position, BulletSpawn2.transform.rotation);
        Instantiate(Bullet, BulletSpawn3.transform.position, BulletSpawn3.transform.rotation);

    }

    public IEnumerator BandanaShoot()
    {
        yield return new WaitForSeconds(timer);
        
        if (Close == true)
        {
           
            Instantiate(Bullet, BulletSpawn1.transform.position, BulletSpawn1.transform.rotation);
            
        }
        StartCoroutine(BandanaShoot());

    }
}
