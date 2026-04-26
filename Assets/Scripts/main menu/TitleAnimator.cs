using UnityEngine;
using TMPro;
using System.Collections;

public class TitleAnimator : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI subtitleText;
    public GameObject glowLine;
    public GameObject startButton;
    public GameObject quitButton;

    void Start()
    {
        // Hide everything at start
        if (titleText != null)
            titleText.alpha = 0;
        if (subtitleText != null)
            subtitleText.alpha = 0;
        if (glowLine != null)
            glowLine.SetActive(false);
        if (startButton != null)
            startButton.SetActive(false);
        if (quitButton != null)
            quitButton.SetActive(false);

        StartCoroutine(AnimateMenu());
    }

    IEnumerator AnimateMenu()
    {
        // Wait a moment
        yield return new WaitForSeconds(0.5f);

        // Fade in title
        yield return StartCoroutine(
            FadeText(titleText, 0f, 1f, 1.5f));

        // Fade in subtitle
        yield return StartCoroutine(
            FadeText(subtitleText, 0f, 1f, 1.0f));

        // Show glow line
        if (glowLine != null)
            glowLine.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        // Show buttons
        if (startButton != null)
            startButton.SetActive(true);
        if (quitButton != null)
            quitButton.SetActive(true);
    }

    IEnumerator FadeText(
        TextMeshProUGUI text,
        float from, float to, float duration)
    {
        if (text == null) yield break;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            text.alpha = Mathf.Lerp(
                from, to, elapsed / duration);
            yield return null;
        }
        text.alpha = to;
    }
}