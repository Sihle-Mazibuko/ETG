using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Class Description:
/*
 *  This script controls the Player's tile-based movement.
 */
#endregion
public class PlayerController : MonoBehaviour
{
    #region Fields

    // Movement speed
    public float moveSpeed;

    // Solid objects layer
    public LayerMask solidObjectsLayer;

    // Level Geo layer
    public LayerMask levelGeoLayer;

    // Is Player moving?
    private bool _isMoving;

    // Input
    public Vector2 _input;
    public float x;
    public float y;

    // Animator controller
    private Animator _animator;

    // Player
    private GameObject _player;
    private Rigidbody2D rb;




    #endregion

    #region Intialisations

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        weaponHolder = transform.GetChild(0).gameObject;
    }

    private void Awake()
    {
        // Get References
        _player = GameObject.FindGameObjectWithTag("Player");
        _animator = _player.GetComponentInChildren<Animator>();
    }

    #endregion

    #region Move the Player
    

    private void Update()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (x != 0 || y != 0)
        {
            
        }
        // If Player is not moving
        if (!_isMoving)
        {
            // Check for _input to move the Player
            // Left arrow = -1, Right arrow = +1
            

            // Down arrow = -1, Up arrow = +1
           

            // If _input is not 0
            if (_input != Vector2.zero)
            {
                // Set the moveX parameter for Idle
                _animator.SetFloat("moveX", _input.x);

                // Set the moveY parameter for Idle
                _animator.SetFloat("moveY", _input.y);


               
            }
        }

        HanldeRotation();
        // Set the _isMoving parameter for Walk
        _animator.SetBool("isMoving", _isMoving);
    }
    #endregion

    #region Move

    private void FixedUpdate()
    {
        //if (x != 0 && y != 0)
        //{
        //    rb.velocity = new Vector2(x * (moveSpeed/2), y * (moveSpeed/2));
        //}
        //else if (x != 0 || y != 0)
        //{
            rb.velocity = new Vector2(x * moveSpeed, y * moveSpeed);
        //}
       
    }

    private bool isWalkable(Vector3 targetPos)
    {
        // Will take the target position and check if the tile at that position is walkable
        // Check if there's a solid object at a position
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null)
        {
            // Tile is not walkable
            return false;
        }

        // Tile is walkable
        return true;
    }
    #endregion

    #region Aim
    //Aim
    GameObject weaponHolder;
    void HanldeRotation()
    {
        Vector3 displacement = weaponHolder.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weaponHolder.transform.rotation = Quaternion.Euler(0, 0, angle - 180);

    }
    #endregion

   
}



