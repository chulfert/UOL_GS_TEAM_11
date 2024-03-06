using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverPanel; // Assign this in the inspector

    void Start()
    {
        // Ensure the Game Over panel is not visible at the start
        gameOverPanel.SetActive(false);
    }

    // Call this method to show the Game Over overlay
    public void TriggerGameOver()
    {
        gameOverPanel.SetActive(true);
        // Here, you can also pause the game if needed
        Time.timeScale = 0;
        //Destroy the spawner
        FindObjectOfType<Spawner>().enabled = false;
    }

    public void RestartGame()
    {
        // Reload the current scene
       

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Reset the scene to default

    }

    public void QuitGame()
    {
        // Quit the game
        SceneManager.LoadScene("MainMenu");
    }
    
}
