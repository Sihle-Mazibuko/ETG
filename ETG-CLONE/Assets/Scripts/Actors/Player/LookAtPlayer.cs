using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    GameObject PlayerObject;
    public Transform PlayerAim;

    public bool player;

    private void Start()
    {
        if (gameObject.name == "Shot Hand Pivot")
        {
            player = false;
        }
        else
        {
            player = true;
        }
    }

    private void Update()
    {
        if (GameObject.Find("Player ") != null)
        {
            if (player == true)
            {
                PlayerObject = GameObject.Find("Player ");

                // Get Angle in Radians
                float AngleRad = Mathf.Atan2((PlayerObject.transform.position.y+0.4f) - transform.position.y, 
                    PlayerObject.transform.position.x - transform.position.x);

                // Get Angle in Degrees
                float AngleDeg = (180 / Mathf.PI) * AngleRad;

                // Rotate Object
                this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg + 90);
            }
        }
    }
}
