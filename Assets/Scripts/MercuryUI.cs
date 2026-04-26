using UnityEngine;
using TMPro;

public class MercuryUI : MonoBehaviour
{
    public TextMeshProUGUI dayTempText;
    public TextMeshProUGUI nightTempText;
    public Light sunLight;

    void Update()
    {
        // Slightly animate the displayed temperatures
        float t = Mathf.Sin(Time.time * 0.2f);
        float dayTemp = 430f + t * 5f;
        float nightTemp = -180f + t * 3f;

        dayTempText.text = $"Day Side: +{dayTemp:F0}°C";
        nightTempText.text = $"Night Side: {nightTemp:F0}°C";
    }
}