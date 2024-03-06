using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    MasterVolumeController masterVolumeController;

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
    public AudioClip collectHealth;
    public AudioClip collectFuel;
    public AudioClip lowFuel;

    private void Awake()
    {
        masterVolumeController = GameObject.FindGameObjectWithTag("Volume").GetComponent<MasterVolumeController>();
    }

    private void Start()
    {
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.volume = masterVolumeController.musicVolume * 0.8f;
        backgroundMusicSource.Play();

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
