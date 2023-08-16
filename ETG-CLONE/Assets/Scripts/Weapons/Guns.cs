using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{

    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform bulletSpawnPoint;


    public int damage, clipSize, bulletsPerTap;
    public float fireRate, spread, timeBetweenMultiShot, reloadTime;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;
    bool shooting, readyToShoot, reloading;


    RaycastHit2D hit;

    bool isEquipped;

    AudioSource src;

    [SerializeField] AudioClip weaponShotSound;
    [SerializeField] AudioClip weaponEmptySound;


    private void Awake()
    {
        bulletsLeft = clipSize;
        readyToShoot = true;
        src = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Debug.Log(readyToShoot);

        if (transform.parent != null)
        {
            readyToShoot = true;
            isEquipped = true;
            MyInput();
        }
        else
        {
            isEquipped = false;
        }
    }

    void MyInput()
    {
            if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
            else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if ((Input.GetKeyDown(KeyCode.R) && bulletsLeft < clipSize && !reloading) || (bulletsLeft < clipSize && !reloading))
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }

    }

    void Reload() { 
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished()
    {
        bulletsLeft = clipSize;
        reloading = false;
    }


    void Shoot()
    {
        readyToShoot = false;

        //Sounds
        src.clip = weaponShotSound;
        src.Play();

        //Bullet Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 _direction = transform.position + new Vector3(x, y, 0);



        //Prefab shooting
        Instantiate(bulletPref, bulletSpawnPoint.position, bulletSpawnPoint.rotation);


        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", fireRate);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenMultiShot);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

}
