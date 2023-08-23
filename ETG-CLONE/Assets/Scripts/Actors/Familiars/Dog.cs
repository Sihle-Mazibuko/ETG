
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] float stopDistance = 1;
    Transform target;
    float dogSpeed = 7;
    Rigidbody2D rb;
    Animator animator;

    private void Update()
    {
        if(target.GetComponent<PlayerController>()._input.x == 0)
        {

        }

        if(target.transform.localPosition.x < transform.localPosition.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        if (Vector2.Distance(transform.position, target.position) > stopDistance)
        {
            HandleMove();
            animator.SetBool("isWalking", true);
            
        }
        else
        {
            
            animator.SetBool("isWalking", false);
            //Play idle animation
        }
    }


    void HandleMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, dogSpeed * Time.deltaTime);
    }

}