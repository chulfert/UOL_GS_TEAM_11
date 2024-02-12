using System.Collections;
using System.Collections.Generic;
using System;
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
            Debug.Log("Audio Manager is Null");
            audioManager = new GameObject("AudioManager");
            DontDestroyOnLoad(audioManager);
        }

        // Set up audio source
        audioSource = audioManager.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.Log("Audio Source is Null");
            audioSource = audioManager.AddComponent<AudioSource>();
            
            // Audio Source properties
            audioSource.loop = true;
         
        }
    }

    public void PlayClickSound()
    {
        // Play the click sound when a button is clicked
        audioSource.PlayOneShot(clickSound);
    }

    public void UpdateVolume(float volume)
    {
        if (audioSource != null)
        {
            Debug.Log("Updated volume: " + volume);
            audioSource.volume = volume;
            Debug.Log("New volume: " + audioSource);
            //return true;
            return;
        }
        //return false;
        throw new Exception("Sopmething went wrong");

        
    }
}
