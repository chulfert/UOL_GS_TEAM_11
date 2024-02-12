using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MasterAudioController : MonoBehaviour
{
    public ButtonAudioManager buttonAudioManager;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("here");

        UpdateVolume(0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateVolume(float volume)
    {
        Debug.Log("Here 2");
        
        buttonAudioManager = FindObjectOfType<ButtonAudioManager>();
        if (buttonAudioManager != null)
        {
            int maxRetries = 10;
            int retryDelay = 1000;
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                    buttonAudioManager.UpdateVolume(volume);
                    break;
                }
                catch
                {
                    retryCount++;
                    if (retryCount < maxRetries)
                    {
                        Thread.Sleep(retryDelay);
                    }
                    else
                    {
                        Debug.Log("Maximum retries reached");
                    }
                }
            }

            
        }
        
    }
}
