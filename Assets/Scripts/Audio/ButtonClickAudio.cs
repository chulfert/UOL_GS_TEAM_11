using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClickAudio : MonoBehaviour, IPointerClickHandler
{
    public ButtonAudioManager buttonAudioManager;

    // Start is called before the first frame update
    void Start()
    {


    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Get 'ButtonAudioManager' script
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();

        // Call function
        buttonAudioManager.PlayClickSound();

    }

}
