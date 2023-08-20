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


    RaycastHit2D hit;

    bool isEquipped;

    #region Effects

    [Header("EFFECTS")]

    // Name of SFX
    public string weaponShotSfx;
    public string weaponEmptySfx;

    #endregion

    private void Awake()
    {
        currentAmmo = clipSize;
        readyToShoot = true;
    }


    private void Update()
    {

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
            if (allowButtonHold) shooting = Input.GetKey("Fire1") ;
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

    void Reload() 
    { 
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

            #region Instantiate Effects

            // Weapon Shot SFX
            GlobalAudioPlayer.PlaySFX(weaponShotSfx);

            #endregion

            //Bullet Spread
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            Vector3 _direction = transform.position + new Vector3(x, y, 0);



            //Prefab shooting
            Instantiate(bulletPref, bulletSpawnPoint.position, bulletSpawnPoint.rotation);


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
            #region Instantiate Effects

            // Weapon Empty SFX
            GlobalAudioPlayer.PlaySFX(weaponEmptySfx);

            #endregion
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

}
