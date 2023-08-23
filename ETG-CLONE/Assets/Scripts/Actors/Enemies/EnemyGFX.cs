using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    #region Fields

    // AI Path
    public AIPath aiPath;

    #endregion

    #region Update

    private void Update()
    {
        // If vevolity is greater than 0,
        // then enemy is moving to the right
        if (aiPath.desiredVelocity.x >= 0.001f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // If vevolity is less than 0,
        // then enemy is moving to the left
        else if (aiPath.desiredVelocity.x <= -0.001f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    #endregion
}
