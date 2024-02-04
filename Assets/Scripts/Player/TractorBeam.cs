using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    public Camera playerCamera;
    public float beamRange = 100f;
    public LayerMask collectibleLayer; 
    public TractorBeamVisuals beamVisuals; 
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse click
        {
            StartAttracting();
        }
        if (Input.GetMouseButton(1)) // Right mouse button held down
        {
            UpdateBeamPosition();
        }
        if (Input.GetMouseButtonUp(1)) // Right mouse button released
        {
            beamVisuals.StopBeam();
        }
    }

    void StartAttracting()
    {
        // Initial beam setup, if needed
        UpdateBeamPosition();
        Debug.Log("Start attracting");
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
            BaseCollectible collectible = hit.collider.GetComponent<BaseCollectible>();
            if (collectible != null)
            {
                collectible.StartAttracting(gameObject); // Start attracting the collectible
            }
        }
        else
        {
            beamEnd = ray.origin + ray.direction * beamRange;
        }

        beamVisuals.DisplayBeam(transform.position, beamEnd); // Update the visual representation of the beam
    }
}

