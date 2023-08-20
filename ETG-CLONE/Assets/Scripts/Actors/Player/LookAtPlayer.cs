using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject PlayerObject;

    public bool player;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        

        if (GameObject.Find("PLAYER") != null)
        {
            if (player == true)
            {
                PlayerObject = GameObject.Find("PLAYER");

                // Get Angle in Radians
                float AngleRad = Mathf.Atan2(PlayerObject.transform.position.y - transform.position.y, PlayerObject.transform.position.x - transform.position.x);
                // Get Angle in Degrees
                float AngleDeg = (180 / Mathf.PI) * AngleRad;
                // Rotate Object
                this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg + 90);
            }

        }

        

        
    }
}