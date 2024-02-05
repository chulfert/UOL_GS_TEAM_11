using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonClickAudio : MonoBehaviour, IPointerClickHandler
{
    public AudioClip hoverSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = hoverSound;
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverSound);
    }

}
