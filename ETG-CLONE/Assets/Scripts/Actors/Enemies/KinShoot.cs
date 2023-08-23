using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinShoot : MonoBehaviour
{
    public GameObject Bullet;
   

    public float distanceBetweenObjects;

    public GameObject Target;
    public float xPosition;

    public float timer = 1.5f;
    public float CurrentY;
    
    GameObject Enemy;
    GameObject Player;
    

    public GameObject BulletSpawn1;
    public GameObject BulletSpawn2;
    public GameObject BulletSpawn3;
    public GameObject BulletSpawn4;
    public GameObject BulletSpawn5;

    public bool Close;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Hand_Pivot");
        CurrentY = transform.localScale.y;
        Player = GameObject.Find("Player");
        if (Enemy.name == "Bullet Kin")
        {
            Debug.Log(Enemy.name);
            StartCoroutine(Shoot());
        }
        if (Enemy.name == "Bandana Kin")
        {
            Close = false;
            StartCoroutine(BandanaShoot());  
        }
        if (Player.transform.localPosition.x > Target.transform.localPosition.x)
        {

            transform.localScale = new Vector3(transform.localScale.x, CurrentY, transform.localPosition.z);
        }
        if (Player.transform.localPosition.x < Target.transform.localPosition.x)
        {
            transform.localScale = new Vector3(transform.localScale.x, -CurrentY, transform.localPosition.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        xPosition = Player.transform.localPosition.x;

        if (Player.transform.localPosition.x > Target.transform.localPosition.x)
        {
            
            transform.localScale = new Vector3(transform.localScale.x, CurrentY, transform.localPosition.z);
        }
        if (Player.transform.localPosition.x < Target.transform.localPosition.x)
        {
            transform.localScale = new Vector3(transform.localScale.x, -CurrentY, transform.localPosition.z);
        }

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
        Instantiate(Bullet, BulletSpawn4.transform.position, BulletSpawn4.transform.rotation);
        Instantiate(Bullet, BulletSpawn5.transform.position, BulletSpawn5.transform.rotation);
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
