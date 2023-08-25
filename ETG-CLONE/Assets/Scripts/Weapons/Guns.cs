using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //
    public GameObject Target;
    public float ZRotate;

    public Slider Ammo;
    public Text ammoTexts;
    public Text maxAmmo;

    public GameObject AmmoActive;
    public Image CurrentWeapon;

    public Sprite Crosbow;
    public Sprite Shotgun;
    public Sprite Peashooter;
    public Sprite AK47;
    public Sprite RustySidearm;
    //
    public bool isEquipped;

    #region Effects

    [Header("EFFECTS")]

    // Name of SFX
    public string weaponShotSfx;
    public string weaponEmptySfx;

    

    #endregion

    private void Start()
    {
        Target = GameObject.Find("WeaponHolder");
        Ammo = GameObject.Find("Slider").GetComponent<Slider>();
        CurrentWeapon = GameObject.Find("CURRENT WEAPON IMG").GetComponent<Image>();
        ammoTexts = GameObject.Find("AMMO TEXT").GetComponent<Text>();
        maxAmmo = GameObject.Find("MAX AMMO").GetComponent<Text>();
        AmmoActive = GameObject.Find("Slider");

    }

    private void Awake()
    {  
        currentAmmo = clipSize;
        readyToShoot = true;
    }


    private void Update()
    {
        ZRotate = Target.transform.localRotation.z;

        if (ZRotate >-0.7 )
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(ZRotate < -0.7)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }

        if(gameObject.name == "CROSSBOW")
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
        if (gameObject.name == "RustySidearm")
        {
            CurrentWeapon.sprite = RustySidearm;
        }
        if (gameObject.name == "Shotgun")
        {
            CurrentWeapon.sprite = Shotgun;
        }

        ammoTexts.text = (currentAmmo.ToString()+"/"+ clipSize.ToString());
        maxAmmo.text = totalBullets.ToString();

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

        if ((Input.GetKeyDown(KeyCode.R) && currentAmmo < clipSize && !reloading) || (currentAmmo < 1 && !reloading))
        {
            Reload();
        }

        if (readyToShoot && shooting && !reloading && currentAmmo > 0)
        {
            bulletsShot = bulletsPerTap;
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

        if (totalBullets >=1)
        {
            readyToShoot = false;

            #region Instantiate Effects

            // Weapon Shot SFX
            GlobalAudioPlayer.PlaySFX(weaponShotSfx);

            #endregion

            ////Bullet Spread
            //float x = Random.Range(-spread, spread);
            //float y = Random.Range(-spread, spread);

            //Vector3 _direction = transform.position + new Vector3(x, y, 0);



            //Prefab shooting
            Instantiate(bulletPref, bulletSpawnPoint.position, bulletSpawnPoint.rotation);


            currentAmmo--;
            
            bulletsShot--;


            Invoke("ResetShot", fireRate);

            if (currentAmmo > 0 && bulletsShot > 0)
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
