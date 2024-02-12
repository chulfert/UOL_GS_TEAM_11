using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundMusic : MonoBehaviour
{
    public AudioClip backgroundMusic;


    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(backgroundMusic, transform.position);

    }

    // Update is called once per frame
  


}
