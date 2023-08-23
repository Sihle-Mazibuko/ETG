using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{

    [SerializeField] GameObject bulletPref;
    [SerializeField] Transform bulletSpawnPoint;


    public int clipSize, bulletsPerTap, totalAmmo;
    public float fireRate, reloadTime, timeBetweenShots;
    public bool allowButtonHold;

    int currentAmmo, bulletsShot;
    bool shooting, readyToShoot, reloading;
    
    //public GameObject Target;
    //public float ZRotate;

    //public Slider Ammo;
    //public Text TotalAmmo;

    //public GameObject AmmoActive;
    //public Image CurrentWeapon;

    //public Sprite Crosbow;
    //public Sprite Shotgun;
    //public Sprite Peashooter;
    //public Sprite AK47;
    //public Sprite RustySidearm;
    
    #region Effects

    [Header("EFFECTS")]

    // Name of SFX
    public string weaponShotSfx;
    public string weaponEmptySfx;

    

    #endregion

    //private void Start()
    //{
    //    Target = GameObject.Find("WeaponHolder");
    //    Ammo = GameObject.Find("Slider").GetComponent<Slider>();
    //    CurrentWeapon = GameObject.Find("CURRENT WEAPON IMG").GetComponent<Image>();
    //    TotalAmmo = GameObject.Find("AMMO TEXT").GetComponent<Text>();
    //    AmmoActive = GameObject.Find("Slider");
    //    ReloadingTime = reloadTime;

    //}

    private void Awake()
    {
        currentAmmo = clipSize;
        readyToShoot = true;
    }


    private void Update()
    {
        #region dont add these here.
        //ZRotate = Target.transform.localRotation.z;

        //if (ZRotate >-0.7 )
        //{
        //    transform.localScale = new Vector3(1, 1, 1);
        //}
        //else if(ZRotate < -0.7)
        //{
        //    transform.localScale = new Vector3(1, -1, 1);
        //}

        //if(gameObject.name == "CROSSBOW")
        //{
        //    CurrentWeapon.sprite = Crosbow;
        //}
        //if (gameObject.name == "AK-47")
        //{
        //    CurrentWeapon.sprite = AK47;
        //}
        //if (gameObject.name == "PeaShooter")
        //{
        //    CurrentWeapon.sprite = Peashooter;
        //}
        //if (gameObject.name == "RustySidearm")
        //{
        //    CurrentWeapon.sprite = RustySidearm;
        //}
        //if (gameObject.name == "Shotgun")
        //{
        //    CurrentWeapon.sprite = Shotgun;
        //}

        //TotalAmmo.text = (currentAmmo.ToString()+"/"+ totalBullets.ToString());


        //if(ReloadingTime > 0)
        //{
        //    ReloadingTime -= Time.deltaTime;
        //    AmmoActive.SetActive(true);
        //}
        //else
        //{
        //    AmmoActive.SetActive(false);
        //}

        //Ammo.maxValue = reloadTime;
        //Ammo.value = ReloadingTime;
        #endregion

            MyInput();
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

        if (totalAmmo >= 1)
        {
            readyToShoot = false;

            #region Instantiate Effects

            // Weapon Shot SFX
            GlobalAudioPlayer.PlaySFX(weaponShotSfx);

            #endregion

            //Prefab shooting
            Instantiate(bulletPref, bulletSpawnPoint.position, bulletSpawnPoint.rotation);


            currentAmmo--;
            bulletsShot--;
            totalAmmo--;


            Invoke("ResetShot", fireRate);

            if (currentAmmo > 0 && bulletsShot > 0)
            {
                //Sounds
                Invoke("Shoot", timeBetweenShots);

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
