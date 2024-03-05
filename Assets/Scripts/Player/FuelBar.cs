using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FuelBar : MonoBehaviour
{
    public Slider Fuelbar;
    public void SetMaxFuel(float Fuel)
    {
        Fuelbar.maxValue = Fuel;
        Fuelbar.value = Fuel;
    }
    public void SetFuel(float Fuel)
    {
      if (Fuelbar.value == 0.3 * Fuelbar.maxValue) 
        {
            audioManager.PlaySFX(audioManager.lowFuel, masterVolumeController.sfxVolume * 0.1f);
        }
        Fuelbar.value = Fuel;
    }
}
