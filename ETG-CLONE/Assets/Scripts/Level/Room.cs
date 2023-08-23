using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    #region Fields

    public GameObject Doors;

    private GameObject _player;
    public GameObject _virtualCam;

    #endregion

    #region OnCollision

    private void Start()
    {
        // Get references.
        _player = GameObject.FindGameObjectWithTag("Player");
        Doors.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            _virtualCam.SetActive(true);
            
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            _virtualCam.SetActive(false);
            Doors.SetActive(true);
        }
    }

    #endregion
}
