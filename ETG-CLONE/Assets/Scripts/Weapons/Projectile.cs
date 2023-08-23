using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    float lifetime =3;
    [SerializeField] float damage;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    private void Start()
    {
        rb.velocity = transform.right * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.gameObject.name == "PILLOW")
        {
            transform.gameObject.GetComponent<Projectile>().enabled = false;


            if (collision.gameObject.tag == "Enemy" && collision.GetComponent<Health>() != null)
            {
                collision.GetComponent<Health>().TakeDamage(damage);


            }
            Destroy(gameObject, .1f);
        }
    }

}
