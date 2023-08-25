using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform bulletSpawnPoint;


    public int clipSize, bulletsPerTap, totalBullets;
    public float fireRate, bulletSpawnInterval, reloadTime;
    public bool allowButtonHold;

    int currentAmmo, bulletsShot;
    bool shooting, readyToShoot, reloading;

    RaycastHit2D hit;

    #region Effects

    [Header("EFFECTS")]

    // Name of SFX
    public string weaponShotSfx;
    public string weaponEmptySfx;



    #endregion

    private void Start()
    {
        currentAmmo = clipSize;
        readyToShoot = true;
    }


    private void Update()
    {
        if (transform.parent != null)
        {
            readyToShoot = true;
            MyInput();
        }
    }

    void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if ((Input.GetKeyDown(KeyCode.R) && currentAmmo < clipSize && !reloading) || (currentAmmo < 1 && !reloading))
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && currentAmmo > 0)
        {
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

        if (totalBullets != 0)
        {
            readyToShoot = false;

            #region Instantiate Effects

            // Weapon Shot SFX
            GlobalAudioPlayer.PlaySFX(weaponShotSfx);

            #endregion

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
        totalBullets--;
    }

}
