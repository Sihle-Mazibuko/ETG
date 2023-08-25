using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField] float healthValue;
    int keys;
    int currentAmmo;
    int clipSize;

    private void Start()
    {
        keys = GetComponent<UIUpdater>().Keys;
        currentAmmo = GetComponent<Guns>().currentAmmo;
        clipSize = GetComponent<Guns>().clipSize;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<Health>().currentHealth <= 6 && transform.tag == "Health")
            {
                collision.GetComponent<Health>().AddHealth(healthValue);
            }
            else if(transform.tag == "Keys")
            {
                keys++;
            }else if(transform.tag == "Ammo")
            {
                currentAmmo = clipSize;
            }
            gameObject.SetActive(false);
        }
    }
}
