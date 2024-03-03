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
        Fuelbar.value = Fuel;
    }
}
