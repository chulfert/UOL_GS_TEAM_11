using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Camera playerCamera;
    public float laserRange = 100f;
    public LayerMask obstacleLayer;
    public LaserBeam laserBeam;
    AudioManager audioManager;
    MasterVolumeController masterVolumeController;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        masterVolumeController = GameObject.FindGameObjectWithTag("Volume").GetComponent<MasterVolumeController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            StartShootingLaser();
            audioManager.PlaySFX(audioManager.laserBeam, masterVolumeController.sfxVolume);
        }
        if (Input.GetMouseButton(0)) // Left mouse button held down
        {
            UpdateLaserPosition();
        }
        if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            laserBeam.StopLaser();
            audioManager.StopSFX(audioManager.laserBeam);
        }
    }

    void StartShootingLaser()
    {
        // Initial laser setup, if needed
        UpdateLaserPosition();
    }

    void UpdateLaserPosition()
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 laserEnd;

        if (Physics.Raycast(ray, out hit, laserRange, obstacleLayer))
        {
            laserEnd = hit.point;

            // Additional logic if the hit object is an obstacle
            Obstacle obstacle = hit.collider.GetComponent<Obstacle>();
            if (obstacle != null)
            {
                obstacle.TakeDamage(); // Apply damage to the obstacle
            }
        }
        else
        {
            laserEnd = ray.origin + ray.direction * laserRange;
        }

        laserBeam.ShootLaser(transform.position, laserEnd);
    }
}
