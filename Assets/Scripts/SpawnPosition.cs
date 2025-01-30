using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public PlayerController player;

    private float leftBoundary = -8f;
    private float rightBoundary = 8f;
    private float topBoundary = 7.5f;
    private float bottomBoundary = -7.5f;
    private float yOffset = 15f;
    private float xOffset = 25f;

    void Update()
    {
        Vector3 newPosition = player.transform.position;

        // handle vertical movement first
        if (player.transform.position.y < bottomBoundary)
        {
            newPosition.y += yOffset; 
        }
        else if (player.transform.position.y > topBoundary)
        {
            newPosition.y -= yOffset; 
        }
        else
        {
            // handle horizontal movement only if not teleporting vertically
            if (player.transform.position.x < leftBoundary)
            {
                newPosition.x += xOffset; 
            }
            else if (player.transform.position.x > rightBoundary)
            {
                newPosition.x -= xOffset; 
            }
        }

        // update position
        transform.position = newPosition;
    }
}
