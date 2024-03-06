using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryTelling : MonoBehaviour
{
    [System.Serializable]
    public struct Instruction
    {
        public string text; // The instruction text
        public float initialDelay; // Time to wait before showing the text
        public float displayTime; // Time the text is fully visible
        public float fadeDuration; // Time for the text to fade out
    }

    public Instruction[] instructions; // Array of instructions with their parameters
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
            // Delay display of text
            yield return new WaitForSeconds(instruction.initialDelay);

            textComponent.text = instruction.text; // Set current instruction
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 1);

            // Wait for the display time
            yield return new WaitForSeconds(instruction.displayTime);

            // Start fade out
            float currentTime = 0;
            while (currentTime < instruction.fadeDuration)
            {
                float alpha = Mathf.Lerp(1, 0, currentTime / instruction.fadeDuration);
                textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, alpha);
                currentTime += Time.deltaTime;
                yield return null;
            }

            // Ensure it is fully transparent 
            textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 0);
        }

        {
            SceneManager.LoadScene("Level 1");
        }

    }
}
