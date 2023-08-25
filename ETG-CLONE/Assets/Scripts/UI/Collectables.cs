using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] float healthValue;
    int keyAmount;
    int ammo;
    int clip;
    int totalAmmo;

    private void Start()
    {
        keyAmount = GetComponent<UIUpdater>().Keys;
        ammo = GetComponent<Weapon>().currentAmmo;
        clip = GetComponent<Weapon>().clipSize;
        totalAmmo = GetComponent<Weapon>().totalBullets;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<Health>().currentHealth <= 6 && gameObject.tag == "Health")
        {
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
        if (collision.tag == "Player"  && gameObject.tag == "Key")
        {
            keyAmount++;            
            gameObject.SetActive(false);
        }
        if (collision.tag == "Player" && gameObject.tag == "Ammo" )
        {
            ammo = clip;
            totalAmmo += 100;
            gameObject.SetActive(false);
        }
    }
}
