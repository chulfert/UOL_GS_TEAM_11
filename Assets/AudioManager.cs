using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource backgroundMusicSource;
    [SerializeField] AudioSource playerHoverSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--- Audio Clip ---")]
    public AudioClip backgroundMusic;
    public AudioClip playerHover;
    public AudioClip jump;
    public AudioClip hover;
    public AudioClip laserBeam;
    public AudioClip tractorBeam;

    private void Start()
    {
        // backgroundMusicSource.clip = backgroundMusic;
        // backgroundMusicSource.Play();

        playerHoverSource.clip = playerHover;
        playerHoverSource.loop = true;
        playerHoverSource.Play();
 
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        SFXSource.volume = volume;
        SFXSource.PlayOneShot(clip);
    }

    public void StopSFX(AudioClip clip)
    {
        SFXSource.Stop();
    }

    public void UpdateSFXVolume(AudioClip clip, float volume)
    {
        SFXSource.volume = volume;
    }
}
