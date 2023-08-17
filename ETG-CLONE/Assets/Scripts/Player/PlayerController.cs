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
    private Vector2 _input;

    // Animator controller
    private Animator _animator;

    // Player
    private GameObject _player;

    #endregion

    #region Intialisations

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
        // If Player is not moving
        if (!_isMoving)
        {
            // Check for _input to move the Player
            // Left arrow = -1, Right arrow = +1
            _input.x = Input.GetAxisRaw("Horizontal");
            // Down arrow = -1, Up arrow = +1
            _input.y = Input.GetAxisRaw("Vertical");

            // If _input is not 0
            if (_input != Vector2.zero)
            {
                // Set the moveX parameter for Idle
                _animator.SetFloat("moveX", _input.x);

                // Set the moveY parameter for Idle
                _animator.SetFloat("moveY", _input.y);


                // Calculate the target position to which the Player should move to
                // The target postion = the current position of the Player + the _input
                var targetPos = transform.position;
                targetPos.x += _input.x;
                targetPos.y += _input.y;

                // If tile is walkable
                if (isWalkable(targetPos))
                {
                    // Move the Player from her current position to his target position
                    StartCoroutine(Move(targetPos));
                }
            }
        }

        // Set the _isMoving parameter for Walk
        _animator.SetBool("isMoving", _isMoving);
    }
    #endregion

    #region Move

    IEnumerator Move(Vector3 targetPos)
    {
        // Move the Player from her current position to her target position
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            // The Player is moving
            _isMoving = true;

            // If there is a difference which is greater than a small value between the two positions,
            // We use the MoveTowards() function to move the Player towards his target position by a very small amount
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            // This will stop the execution of the Coroutine and resume it in the next Update() function
            yield return null;
        }

        // Set the current position of the Player to the target position
        transform.position = targetPos;

        // The Player is not moving
        _isMoving = false;

        // Check for encounters with NPCs on the Level Geo tiles
        CheckForEncounters();
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

    #region Check For Encounters

    private void CheckForEncounters()
    {
        // Check if the tile the Player is walking on is a Level Geo tile
        if (Physics2D.OverlapCircle(transform.position, 0.2f, levelGeoLayer) != null)
        {
            // You encountered an NPC
            // Debug.Log("You encountered an NPC.");
        }
    }
    #endregion
}
