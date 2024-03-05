using System.Collections;
using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class InGameInstructions : MonoBehaviour
{
    public float delayBeforeFade = 12f; // Time in seconds before starting the fade-out effect
    public float fadeDuration = 2f; // Duration of the fade-out effect

    void Start()
    {
        StartCoroutine(FadeOutAfterDelay());
    }

    IEnumerator FadeOutAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeFade);

        float currentTime = 0;
        TextMeshProUGUI textComponent = GetComponent<TextMeshProUGUI>(); // Use TextMeshProUGUI for UI text, or TextMeshPro for 3D text

        if (textComponent == null)
        {
            Debug.LogError("TextMeshPro component not found on the object.", this);
            yield break; // Exit the coroutine if the TextMeshPro component is not found
        }

        Color originalColor = textComponent.color;

        while (currentTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0.549f, 0f, currentTime / fadeDuration);
            textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }

        textComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        gameObject.SetActive(false);
    }
}