using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudioManager : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        // Ensure the audio source persists between scenes
        GameObject audioManager = GameObject.Find("AudioManager");

        // Create new audio manager on play
        if (audioManager == null)
        {
            audioManager = new GameObject("AudioManager");
            DontDestroyOnLoad(audioManager);
        }

        // Set up audio source
        audioSource = audioManager.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = audioManager.AddComponent<AudioSource>();
            
            // Audio Source properties
            audioSource.loop = true;
            audioSource.volume = 2.0f;
        }
    }

    public void PlayClickSound()
    {
        // Play the click sound when a button is clicked
        audioSource.PlayOneShot(clickSound);
    }
}
