using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    Transform weaponHolder;
    GameObject weapon;

    [SerializeField]
    private LayerMask gunMask;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Weapon")
    //    {
    //        Debug.Log("i see a weapon");
    //    }
    //}

    void Detection()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, transform.right, 5);
        Debug.DrawLine(worldPoint, worldPoint + (Vector2)transform.right * 5, Color.red);
        if (hit.collider != null)
        {
            Debug.Log("i see " + hit.collider.transform.name);

        }
    }

    private void Update()
    {
        Detection();
    }

    //void PickUpWeapon()
    //{
    //    if (weapon == null)
    //    {
    //        Debug.Log("????");
    //        Collider2D weaponItem = Physics2D.OverlapCircle(transform.position, 1, gunMask.value);
    //        Debug.Log(weaponItem.gameObject.name);

    //        if (weaponItem)
    //        {
    //            weapon = weaponItem.gameObject;
    //            weapon.transform.position = weaponHolder.position;
    //            weapon.transform.parent = weaponHolder;
    //            if (weapon.GetComponent<Rigidbody2D>())
    //            {
    //                weapon.GetComponent<Rigidbody2D>().simulated = false;
    //            }
    //        }
    //    }
    //}
}
