using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JupiterUI : MonoBehaviour
{
    [Header("UI References")]
    public Button backButton;
    public TextMeshProUGUI stormText;
    public TextMeshProUGUI windText;
    public TextMeshProUGUI moonText;
    public TextMeshProUGUI rotationText;

    void Start()
    {
        if (moonText != null)
            moonText.text = "MOONS: 4 (GALILEAN)";

        if (rotationText != null)
            rotationText.text = "ROTATION: 9.93 HOURS";
    }

    void Update()
    {
        float t = Time.time;

        float wind = 620f + Mathf.Sin(t * 0.3f) * 40f;
        if (windText != null)
            windText.text = $"WIND: {wind:F0} m/s";

        float stormPulse = Mathf.Sin(t * 0.15f);

        string stormLevel =
            stormPulse > 0.4f ? "STORM: INTENSE ▲▲" :
            stormPulse > 0f ? "STORM: ACTIVE ▲" :
                               "STORM: ACTIVE";

        if (stormText != null)
            stormText.text = stormLevel;
    }
}