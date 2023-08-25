using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform bulletSpawnPoint;


    public int clipSize, bulletsPerTap, totalBullets;
    public float fireRate, bulletSpawnInterval, reloadTime;
    public bool allowButtonHold;

    int bulletsShot;
    bool shooting, readyToShoot, reloading, isEquipped;
    public int currentAmmo { get; private set; }

    Text ammoText;
    Text totalAmmoTxt;

    Image CurrentWeapon;

    public Sprite Crosbow;
    public Sprite Peashooter;
    public Sprite AK47;
    public Sprite RustySidearm;
    public Sprite M1911;
    public Sprite Silencer;
    public Sprite Magnum;
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
        ammoText = GameObject.Find("AMMO TEXT").GetComponent<Text>();
        totalAmmoTxt = GameObject.Find("total ammo").GetComponent<Text>();
        CurrentWeapon = GameObject.Find("CURRENT WEAPON IMG").GetComponent<Image>();

    }


    private void Update()
    {
        if (transform.parent != null)
        {
            readyToShoot = true;
            MyInput();
            isEquipped = true;
            ammoText.text = currentAmmo.ToString() + "/" + clipSize.ToString();
            totalAmmoTxt.text = totalBullets.ToString();
            Changeimg();
        }
        else
        {
            isEquipped=false;
        }
    }

    void Changeimg()
    {
        if (gameObject.name == "CROSSBOW")
        {
            CurrentWeapon.sprite = Crosbow;
        }
        if (gameObject.name == "AK-47")
        {
            CurrentWeapon.sprite = AK47;
        }
        if (gameObject.name == "PeaShooter")
        {
            CurrentWeapon.sprite = Peashooter;
        }
        if (gameObject.name == "M1911")
        {
            CurrentWeapon.sprite = M1911;
        }
        if (gameObject.name == "SILENCER")
        {
            CurrentWeapon.sprite = Silencer;
        }
        if (gameObject.name == "RustySidearm")
        {
            CurrentWeapon.sprite = RustySidearm;
        }

        if (gameObject.name == "MAGNUM")
        {
            CurrentWeapon.sprite = Magnum;
        }

    }

    void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if ((Input.GetKeyDown(KeyCode.R) && currentAmmo < clipSize && !reloading) || (currentAmmo <= 0 && !reloading))
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

        if (totalBullets >= 1)
        {
            readyToShoot = false;

            #region Instantiate Effects

            // Weapon Shot SFX
            GlobalAudioPlayer.PlaySFX(weaponShotSfx);

            #endregion

            //Prefab shooting
            Instantiate(bulletPref, bulletSpawnPoint.position, bulletSpawnPoint.rotation);


            currentAmmo--;


            Invoke("ResetShot", fireRate);

            if (currentAmmo > 0 && bulletsShot > 0)
            {
                //Sounds
                Invoke("Shoot", bulletSpawnInterval);
                totalBullets--;

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
