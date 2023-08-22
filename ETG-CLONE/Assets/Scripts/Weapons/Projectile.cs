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
            coll.GetComponent<Health>().currentHealth -= 1;
            Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Player")
        {

            Instantiate(Boom, transform.position, transform.rotation);
            coll.GetComponent<Health>().currentHealth -= 1;
            Destroy(gameObject);
        }
    }


    public IEnumerator Break()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

}
