using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifetime =3;
    [SerializeField] float damage;
    public GameObject Boom;
    public BulletController controller;

    Rigidbody2D rb;
    //[SerializeField] GameObject bloodSplatter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    private void Start()
    {
        StartCoroutine(Break());
        rb.velocity = transform.right * speed;
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {

            Instantiate(Boom, transform.position, transform.rotation);
            coll.GetComponent<Health>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Structure")
        {

            Instantiate(Boom, transform.position, transform.rotation);
           
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Player")
        {

            Instantiate(Boom, transform.position, transform.rotation);
            if (gameObject.name != "BuckShot")
            {
                coll.GetComponent<Health>().TakeDamage(1);
            }
            else if (controller.Hit == false)
            {
                coll.GetComponent<Health>().TakeDamage(1);
            }

            if (gameObject.name == "BuckShot")
            {
                controller.Hit = true;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }


    public IEnumerator Break()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

}
