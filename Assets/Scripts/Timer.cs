using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float startTime;
    private bool isRunning = false;
    public float currentTime { get; private set; }
    public Text TimerText;

    void Update()
    {
        if (isRunning)
        {
            currentTime = Time.time - startTime;
            // Optionally, display the current time in the UI
            TimerText.text = "Time: " + currentTime.ToString("F2");
            
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void StopTimerAndSaveHighscore()
    {
        isRunning = false;
        SaveHighscore(currentTime);
    }

    private void SaveHighscore(float time)
    {
        // Load existing high scores
        List<float> highScores = PlayerPrefs.GetString("HighScores", "")
            .Split(',')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(float.Parse)
            .ToList();

        // Add the new time
        highScores.Add(time);

        // Sort the list to ensure the best times are first
        highScores = highScores.OrderBy(x => x).ToList();

        // Optional: Limit the number of saved high scores
        if (highScores.Count > 10) // Keep top 10 scores
        {
            highScores = highScores.Take(10).ToList();
        }

        // Save the updated list
        PlayerPrefs.SetString("HighScores", string.Join(",", highScores.Select(x => x.ToString()).ToArray()));
        PlayerPrefs.Save();
    }
}
