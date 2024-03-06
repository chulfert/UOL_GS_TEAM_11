using System.Collections;
using UnityEngine;
using TMPro;

public class InGameInstructions : MonoBehaviour
{
    public string[] instructions; // Array for instructions
    public float displayTime = 6f; // Time in seconds
    public float fadeDuration = 1f; // Duration of fade-out 
    public TextMeshProUGUI textComponent; 

    void Start()
    {
        if (textComponent == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned.", this);
            return;
        }
        
        StartCoroutine(DisplayInstructionsSequence());
    }

    IEnumerator DisplayInstructionsSequence()
    {
        foreach (var instruction in instructions)
        {
            textComponent.text = instruction; // Current instruction
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 1f); 

            yield return new WaitForSeconds(displayTime); // Wait for the display time

            // Start fade out
            float currentTime = 0;
            while (currentTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(1f, 0f, currentTime / fadeDuration);
                textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, alpha);
                currentTime += Time.deltaTime;
                yield return null;
            }

            // Ensure it is fully transparent 
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0);
        }

        gameObject.SetActive(false); // Hide canvas
    }
}
