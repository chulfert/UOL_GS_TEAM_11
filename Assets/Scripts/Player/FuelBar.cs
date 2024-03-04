using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FuelBar : MonoBehaviour
{
    AudioManager audioManager;
    MasterVolumeController masterVolumeController;
    public Slider Fuelbar;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        masterVolumeController = GameObject.FindGameObjectWithTag("Volume").GetComponent<MasterVolumeController>();
    }

    public void SetMaxFuel(float Fuel)
    {
        Fuelbar.maxValue = Fuel;
        Fuelbar.value = Fuel;
    }
    public void SetFuel(float Fuel)
    {
        Fuelbar.value = Fuel;
        if (Fuelbar.value == 0.3 * Fuelbar.maxValue) 
        {
            audioManager.PlaySFX(audioManager.lowFuel, masterVolumeController.sfxVolume * 0.1f);
        }
    }
}
