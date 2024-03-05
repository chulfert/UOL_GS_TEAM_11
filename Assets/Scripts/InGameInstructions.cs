using System.Collections;
using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class InGameInstructions : MonoBehaviour
{
    public string[] instructions; // Array to hold the instructions
    public float displayTime = 6f; // Time in seconds each instruction is fully visible
    public float fadeDuration = 2f; // Duration of the fade-out effect
    public TextMeshProUGUI textComponent; // Assign this in the inspector

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
            textComponent.text = instruction; // Set the current instruction text
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0.549f); // Make sure it's fully visible

            yield return new WaitForSeconds(displayTime); // Wait for the display time

            // Start fade out
            float currentTime = 0;
            while (currentTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(0.549f, 0f, currentTime / fadeDuration);
                textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, alpha);
                currentTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the text is fully transparent before moving to the next instruction
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0);
        }

        gameObject.SetActive(false); // Optionally hide or disable the game object after all instructions have been shown
    }
}
