using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollectible : MonoBehaviour
{
    protected bool isAttracted = false;
    protected GameObject player;
    AudioManager audioManager;
    MasterVolumeController masterVolumeController;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        masterVolumeController = GameObject.FindGameObjectWithTag("Volume").GetComponent<MasterVolumeController>();
    }

    public virtual void StartAttracting(GameObject playerObject)
    {
        isAttracted = true;
        player = playerObject;
    }

    public virtual void StopAttracting()
    {
        isAttracted = false;
    }

    protected virtual void Update()
    {
        if (isAttracted)
        {
           // Move towards the player
            float step = 15f * Time.deltaTime; // Adjust speed as needed
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        //Debug.Log(player);
        if (other.gameObject == player)
        {
            Collect();
            audioManager.StopSFX(audioManager.tractorBeam);
            audioManager.PlaySFX(audioManager.collectFuel, masterVolumeController.sfxVolume);
        }
    }

    protected virtual void Collect()
    {
        // Collect the item or disable it
        gameObject.SetActive(false);
    }
}
