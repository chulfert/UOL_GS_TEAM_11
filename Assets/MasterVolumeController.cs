using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeController : MonoBehaviour
{
    private static MasterVolumeController instance;
    public float musicVolume;
    public float sfxVolume;
  
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicVolume = 1.0f;
        sfxVolume = 1.0f;
        musicSlider.onValueChanged.AddListener(OnMusicValueChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXValueChanged);
    }

    private void OnMusicValueChanged(float value)
    {
        musicVolume = value;
        Debug.Log("Music Volume: " + musicVolume);
    }

    private void OnSFXValueChanged(float value)
    {
        sfxVolume = value;
        Debug.Log("SFX Volume: " + sfxVolume);
    }

    private void OnDestroy()
    {
        musicSlider.onValueChanged.RemoveListener(OnMusicValueChanged);
        sfxSlider.onValueChanged.RemoveListener(OnSFXValueChanged);
    }

    public void setMasterVolume(float volume)
    {
        musicVolume = volume;
    }
}
