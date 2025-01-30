using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;

    private int currentSceneIndex;        

    public PlayerController player;
    public Transform spawnPosition;

    private List<Scene> traversedScenes = new List<Scene>();
    

    void OnEnable()
    {        
        SceneManager.sceneLoaded += OnSceneLoaded;        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        
        Debug.Log("OnSceneLoaded: " + scene.name);
        gameManager.currentState = GameManager.GameState.Playing;

        Debug.Log($"Current State: {gameManager.currentState}");

        HandlePlayerSpawn();
    }

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        Debug.Log($"Started | Current Scene: {currentSceneIndex}");
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;        
    }

    public void LoadNextLevel()
    {
        gameManager.currentState = GameManager.GameState.LoadingLevel;
        Debug.Log($"Current State: {gameManager.currentState}");
        
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex += 1;
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            currentSceneIndex = 0;
            SceneManager.LoadScene(currentSceneIndex);
        }


    }     
    
    void HandlePlayerSpawn()
    {
        player.transform.position = spawnPosition.position;
        Debug.Log(player.transform.position);
    }
}
