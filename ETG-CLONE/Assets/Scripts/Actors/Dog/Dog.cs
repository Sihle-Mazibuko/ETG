using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] float stopDistance =1;
    Transform target;
    float dogSpeed = 7;
    Rigidbody2D rb;
    Animator animator;


    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        if(Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            HandleMove();
            animator.SetTrigger("isWalking");
        }
        else
        {
            animator.SetTrigger("Sit");
            //Play idle animation
        }
    }


    void HandleMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, dogSpeed * Time.deltaTime);
    }

    //bool facingRight = true;

    //void Flip()
    //{
    //    facingRight = !facingRight;
    //    transform.Rotate(0, 180, 0);
    //}
}
