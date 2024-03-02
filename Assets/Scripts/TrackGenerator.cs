using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public GameObject trackPiecePrefab;
    public int segmentLength = 5; // Number of track pieces in a segment
    public int numSegments = 10; // Total number of segments to generate
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
                // Determine if the piece should be missing
                if (Random.value > missingPieceProbability)
                {
                    Instantiate(trackPiecePrefab, spawnPosition, Quaternion.identity);
                }

                spawnPosition += new Vector3(trackPiecePrefab.transform.localScale.x, 0f, 0f); // Adjust position for next track piece
            }

            // Reset x position and move forward for next segment
            spawnPosition.x = 0f;
            spawnPosition.z += trackPiecePrefab.transform.localScale.z;
        }
    }
}
