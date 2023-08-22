using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifetime =3;
    [SerializeField] float damage;


    Rigidbody2D rb;
    //[SerializeField] GameObject bloodSplatter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      

        Health hitCharacter = collision.gameObject.GetComponent<Health>();
        //Instantiate(bloodSplatter, collision.transform.position, Quaternion.identity);

        if (hitCharacter != null && hitCharacter.tag == "Enemy")
        {
            hitCharacter.TakeDamage(damage);
        }
        Destroy(gameObject, .1f);
    }

}
