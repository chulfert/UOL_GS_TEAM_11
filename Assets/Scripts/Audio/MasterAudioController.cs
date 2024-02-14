using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MasterAudioController : MonoBehaviour
{
    public ButtonAudioManager buttonAudioManager;
    public float masterVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("here");

        //UpdateVolume(0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume(float volume)
    {
        Debug.Log("Here 2");
        
        buttonAudioManager = GetComponent<ButtonAudioManager>();
        
        if (buttonAudioManager == null)
        {
            
            int maxRetries = 10;
            int retryDelay = 1000;
            int retryCount = 0;
  
            while (retryCount < maxRetries)
            {
                
                try
                {
                    buttonAudioManager.UpdateVolume(volume);
                    
                }
                catch
                {
                    retryCount++;
                    if (retryCount < maxRetries)
                    {
                        
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
