using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeController : MonoBehaviour
{
    public float masterVolume;
    public Slider slider;

    private void Start()
    {
        // Subscribe to the OnValueChanged event of the slider
        masterVolume = 1.0f;
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    // This method will be called whenever the slider value changes
    private void OnSliderValueChanged(float value)
    {
        // Do whatever you want with the slider value here
        masterVolume = value;
        AudioListener.volume = masterVolume;
        Debug.Log("Slider Value: " + masterVolume + AudioListener.volume);
    }

    // Remember to unsubscribe from the event when the script is disabled or destroyed
    private void OnDestroy()
    {
        slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }


    public void setMasterVolume(float volume)
    {
        masterVolume = volume;
    }
}
