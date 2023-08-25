using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifetime =3;
    [SerializeField] float damage;
    public GameObject Boom;

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

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Room")
        {
            Debug.Log("im touching the floor");
        }
        else if(coll.gameObject.tag == "Enemy")
        {
                Instantiate(Boom, transform.position, transform.rotation);
                coll.GetComponent<Health>().TakeDamage(damage);
            Debug.Log("i hurt the enemy");


            Destroy(gameObject, .1f); 
        }else if(coll.gameObject.tag == "Structure")
        {
            Instantiate(Boom, transform.position, transform.rotation);
            Destroy(gameObject, .1f);
        }
        Destroy(gameObject, .1f);

    }



}
