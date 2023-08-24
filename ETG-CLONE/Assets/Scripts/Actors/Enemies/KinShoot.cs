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
    
    public GameObject Enemy;
    public GameObject Player;
    

    public GameObject BulletSpawn1;


    public bool Close;
    public float Distance;
    public float TriggerDistance;
    private float distanceX;
    private float distanceY;
   

    void Start()
    {
        Target = GameObject.Find("Hand_Pivot");

        CurrentY = transform.localScale.y;

        Player = GameObject.Find("Player");

        if (Enemy.name == "Bullet Kin(Clone)")
        {
            StartCoroutine(Shoot());
        }

        if (Enemy.name == "Bandana Kin(Clone)")
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
    private void Update()
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

        Debug.DrawLine(transform.position, Player.transform.position, Color.green);
        Vector2 delta = transform.position - Player.transform.position;
        distanceX = delta.x;
        distanceY = delta.y;
        
        Distance = delta.magnitude;

        if (Distance <= TriggerDistance)
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
       
    }

    public IEnumerator BandanaShoot()
    {
        yield return new WaitForSeconds(timer);
        Debug.Log("Bang");
        if (Close == true)
        {
            Instantiate(Bullet, BulletSpawn1.transform.position, BulletSpawn1.transform.rotation);
        }

        StartCoroutine(BandanaShoot());
    }
}
