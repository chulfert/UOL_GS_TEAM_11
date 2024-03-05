using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public GameObject trackPiecePrefab;
    public GameObject portalPrefab;
    int segmentLength = 5; // Number of track pieces in a segment
    public int numSegments = 0; // Total number of segments to generate
    [Range(0f, 1f)] public float missingPieceProbability = 0.2f; // Probability of a piece being missing

    void Start()
    {
        GenerateTrack();
    }

    void GenerateTrack()
    {
        Vector3 spawnPosition = Vector3.zero;

        for (int i = 0; i < numSegments; i++)
        {
            for (int j = 0; j < segmentLength; j++)
            {
                // Generate a random numberbased on Perlin noise and the current position
                float noise = Mathf.PerlinNoise(spawnPosition.x * 0.2f, spawnPosition.z * 0.2f);
                
                // Determine if the piece should be missing
                if (noise > missingPieceProbability)
                {
                    Instantiate(trackPiecePrefab, spawnPosition, Quaternion.identity);
                }
                // in some cases generate a second level

                if (noise > 0.77)
                {
                    spawnPosition.y = 4;
                    Instantiate(trackPiecePrefab, spawnPosition, Quaternion.identity);
                    spawnPosition.y = 0;
                }

                spawnPosition += new Vector3(trackPiecePrefab.transform.localScale.x, 0f, 0f); // Adjust position for next track piece
            }

            // Reset x position and move forward for next segment
            spawnPosition.x = 0f;
            spawnPosition.z += trackPiecePrefab.transform.localScale.z;
        }

        // Portal at the end of the track
        Instantiate(portalPrefab, spawnPosition, Quaternion.identity);
    }


}
