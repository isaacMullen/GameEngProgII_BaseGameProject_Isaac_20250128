using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public PlayerController player;
       
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;       

        //checking if player is at the bottom of the screen
        if (player.transform.position.y < -7.4f)
        {
            transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + 15.2f, player.transform.position.z);
        }
        //checking if player is at the left side of the screen
        if (player.transform.position.x < -15f)
        {
            transform.position = new Vector3(player.transform.position.x + 32f, player.transform.position.y, player.transform.position.z);
        }
        //checking if player is at the top of the screen
        if (player.transform.position.y > 7.4f)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 15.2f, player.transform.position.z);
        }
        //checking if player is at the right side of the screen
        if (player.transform.position.x > 15f)
        {
            transform.position = new Vector3(player.transform.position.x - 32f, player.transform.position.y, player.transform.position.z);
        }        
    }
}
