using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeTrigger : MonoBehaviour
{    
    public LevelManager levelManager;            

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {            
            levelManager.LoadNextLevel();
        }
    }
}
