using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeamVisuals : MonoBehaviour
{
    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

    public void DisplayBeam(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.enabled = true;

        // You might want to add additional visual effects specific to the tractor beam here,
        // like changing the color or adding some particle effects to simulate a 'tractor' effect.
    }

    public void StopBeam()
    {
        lineRenderer.enabled = false;

        // Also ensure to stop or clear any additional effects you started in DisplayBeam.
    }
}