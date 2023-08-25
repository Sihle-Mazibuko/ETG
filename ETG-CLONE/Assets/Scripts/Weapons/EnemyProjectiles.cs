using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class EnemyProjectiles : MonoBehaviour
{
    public GameObject Boom;
    public BulletController controller;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            Instantiate(Boom, transform.position, transform.rotation);
            if (gameObject.name != "BuckShot")
            {
                collision.GetComponent<Health>().TakeDamage(1);
            }
            else if (controller.Hit == false)
            {
                collision.GetComponent<Health>().TakeDamage(1);
            }

            if (gameObject.name == "BuckShot")
            {
                controller.Hit = true;
            }

        }
        Destroy(gameObject, .1f);

    }
}
