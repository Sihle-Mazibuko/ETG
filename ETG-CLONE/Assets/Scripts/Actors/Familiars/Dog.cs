
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    #region Fields

    [SerializeField] 
    private float stopDistance = 1;
    private Transform target;
    private float dogSpeed = 7;
    private Rigidbody2D rigidBody;
    Animator animator;

    #endregion

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {

        if (target.transform.localPosition.x < transform.localPosition.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
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