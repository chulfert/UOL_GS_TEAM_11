using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{


    // Detect if the player has entered the portal
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // if current scene is level 1
            if(SceneManager.GetActiveScene().name == "Level1")
            {
                // Stop the timer and save the highscore
                GameObject.Find("Timer").GetComponent<Timer>().StopTimerAndSaveHighscore();
                // Close the scene and load level 2
                SceneManager.LoadScene("Level2");
            }
            else
            {
                // goto main menu
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
