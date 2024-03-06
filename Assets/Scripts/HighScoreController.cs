using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    public GameObject HighScorePanel;

    void Start()
    {
        GetFormattedHighScores();
    }
    public void GetFormattedHighScores()
    {
        List<float> highScores = PlayerPrefs.GetString("HighScores", "")
            .Split(',')
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(float.Parse)
            .OrderBy(x => x)
            .ToList();

        // Sort the list to ensure the best times are first
        highScores = highScores.OrderBy(x => x).ToList();

        // on the panel create a new text object for each high score
        for (int i = 0; i < 10; i++)
        {
            GameObject newHighScore = new GameObject("HighScore" + i);
            newHighScore.transform.SetParent(HighScorePanel.transform);
            newHighScore.AddComponent<Text>().text = (i + 1) + ". " + highScores[i].ToString("F2") + "s";
            // Set the text object's position and size
            newHighScore.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -i * 30);
            newHighScore.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 30);
            // Set the text object's font and color´and size
            newHighScore.GetComponent<Text>().font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            newHighScore.GetComponent<Text>().color = Color.white;
            newHighScore.GetComponent<Text>().fontSize = 20;


        }
    }
}
