using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    public Camera playerCamera;
    public float beamRange = 100f;
    public LayerMask collectibleLayer; 
    public TractorBeamVisuals beamVisuals; 
    AudioManager audioManager;
    MasterVolumeController masterVolumeController;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        masterVolumeController = GameObject.FindGameObjectWithTag("Volume").GetComponent<MasterVolumeController>();
    }

    private BaseCollectible currentCollectible;
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse click
        {
            StartAttracting();
            audioManager.PlaySFX(audioManager.tractorBeam, masterVolumeController.sfxVolume * 0.2f);
        }
        if (Input.GetMouseButton(1)) // Right mouse button held down
        {
            UpdateBeamPosition();
        }
        if (Input.GetMouseButtonUp(1)) // Right mouse button released
        {
            beamVisuals.StopBeam();
            if (currentCollectible != null)
            {
                currentCollectible.StopAttracting();
                currentCollectible = null;
            }
            audioManager.StopSFX(audioManager.tractorBeam);
        }
    }

    void StartAttracting()
    {
        // Initial beam setup, if needed
        UpdateBeamPosition();
    }

    void UpdateBeamPosition()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 beamEnd;

        if (Physics.Raycast(ray, out hit, beamRange, collectibleLayer))
        {
            beamEnd = hit.point;
            // Check if the hit object is a collectible and start attracting it
            currentCollectible = hit.collider.GetComponent<BaseCollectible>();
            if (currentCollectible != null)
            {
                currentCollectible.StartAttracting(gameObject); // Start attracting the collectible
            }
        }
        else
        {
            beamEnd = ray.origin + ray.direction * beamRange;
            currentCollectible = null;
        }

        Vector3 beamPosition = transform.position + Vector3.right * 1f;

        beamVisuals.DisplayBeam(beamPosition, beamEnd); // Update the visual representation of the beam
    }
}

