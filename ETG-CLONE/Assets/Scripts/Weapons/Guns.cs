using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{

    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform bulletSpawnPoint;


    public int clipSize, bulletsPerTap, totalBullets;
    public float fireRate, spread, bulletSpawnInterval, reloadTime;
    public bool allowButtonHold;

    int currentAmmo, bulletsShot;
    bool shooting, readyToShoot, reloading;

    public PlayerController player;


    RaycastHit2D hit;

    bool isEquipped;

    AudioSource src;

    [SerializeField] AudioClip weaponShotSound;
    [SerializeField] AudioClip weaponEmpty;

    public GameObject BulletShoot;
    public GameObject BulletSpawn;

    Vector3 mouse_pos;
    
    Vector3 object_pos;
    float angle;

    private void Awake()
    {
        currentAmmo = clipSize;
        readyToShoot = true;
        src = GetComponent<AudioSource>();
    }

    private void Start()
    {
        BulletSpawn = GameObject.Find("BulletSpawn ");
        
        BulletShoot = GameObject.Find("WEAPON HOLDER");
        
        player = GameObject.Find("PLAYER").GetComponent<PlayerController>();
    }

    private void Update()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23f; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(BulletSpawn.transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        BulletSpawn.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (player._input.x < 0 && player._input.y == 0)
        {
            BulletShoot.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (player._input.x > 0 && player._input.y == 0)
        {
            BulletShoot.transform.localScale = new Vector3(1, 1, 1);
        }
        if (transform.parent != null)
        {
            isEquipped = true;
            readyToShoot = true;
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

        if ((Input.GetKeyDown(KeyCode.R) && currentAmmo < clipSize && !reloading) || (currentAmmo < clipSize && !reloading))
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && currentAmmo > 0)
        {
            bulletsPerTap = bulletsShot;
            Shoot();
        }
    }

    void Reload() { 
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished()
    {
        currentAmmo = clipSize;
        reloading = false;
    }


    void Shoot()
    {

        if (bulletsShot < totalBullets)
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
            Instantiate(bulletPref, BulletSpawn.transform.position, BulletSpawn.transform.rotation);


            currentAmmo--;
            bulletsShot++;


            Invoke("ResetShot", fireRate);

            if (currentAmmo > 0)
            {
                //Sounds
                Invoke("Shoot", bulletSpawnInterval);

            }

        }
        else
        {
            src.clip = weaponEmpty;
            src.Play();

        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

}
