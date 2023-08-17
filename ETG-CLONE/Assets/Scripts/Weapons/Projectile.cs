using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifetime;
    [SerializeField] float damage;

    public GameObject WeaponHolster;


    Rigidbody2D rb;
    //[SerializeField] GameObject bloodSplatter;

    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        WeaponHolster = GameObject.Find("WEAPON HOLDER");
        //if (WeaponHolster.transform.localScale == new Vector3(-1, 1, 1))
        //{
            //rb.velocity = -transform.right * speed;
            rb.velocity = transform.right * speed;
        //}
        //if (WeaponHolster.transform.localScale == new Vector3(1, 1, 1))
        //{
        //    rb.velocity = transform.right * speed;
        //}
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      

        Health hitCharacter = collision.gameObject.GetComponent<Health>();
        //Instantiate(bloodSplatter, collision.transform.position, Quaternion.identity);

        if (hitCharacter != null)
        {
            hitCharacter.TakeDamage(damage);
        }
        Destroy(gameObject,.1f);

    }
}
