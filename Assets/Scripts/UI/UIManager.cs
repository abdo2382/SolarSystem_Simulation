using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    [Header("Simulation")]
    public UnityEngine.UI.Button simulationButton;
    private PlanetData _currentData;
    public static UIManager Instance;

    [Header("Panels")]
    public GameObject planetInfoPanel;
    public GameObject hoverLabel;

    [Header("Planet Info Fields")]
    public TextMeshProUGUI planetNameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI diameterText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI orbitalPeriodText;
    public TextMeshProUGUI rotationPeriodText;
    public TextMeshProUGUI moonsText;
    public TextMeshProUGUI temperatureText;
    public TextMeshProUGUI gravityText;
    public TextMeshProUGUI atmosphereText;
    public TextMeshProUGUI funFactText;

    [Header("Hover Label")]
    public TextMeshProUGUI hoverLabelText;

    void Awake()
    {
        Instance = this;

        // Hide both at start
        if (planetInfoPanel != null)
            planetInfoPanel.SetActive(false);

        if (hoverLabel != null)
            hoverLabel.SetActive(false);
    }

    public void ShowPlanetInfo(PlanetData data)
    {
        if (data == null)
        {
            Debug.Log("PlanetData is NULL");
            return;
        }

        // Show the panel
        if (planetInfoPanel != null)
            planetInfoPanel.SetActive(true);

        // Fill in all fields safely
        if (planetNameText != null)
            planetNameText.text = data.planetName;

        if (descriptionText != null)
            descriptionText.text = data.description;

        if (diameterText != null)
            diameterText.text = data.diameter;

        if (distanceText != null)
            distanceText.text = data.distanceFromSun;

        if (orbitalPeriodText != null)
            orbitalPeriodText.text = data.orbitalPeriod;

        if (rotationPeriodText != null)
            rotationPeriodText.text = data.rotationPeriod;

        if (moonsText != null)
            moonsText.text = data.numberOfMoons;

        if (temperatureText != null)
            temperatureText.text = data.surfaceTemperature;

        if (gravityText != null)
            gravityText.text = data.gravity;

        if (atmosphereText != null)
            atmosphereText.text = data.atmosphere;

        if (funFactText != null)
            funFactText.text = data.funFact;

        Debug.Log("Showing info for: "
            + data.planetName);

        _currentData = data;

        if (simulationButton != null)
        {
            simulationButton.onClick.RemoveAllListeners();
            simulationButton.onClick.AddListener(() =>
            {
                SceneLoader.Instance
                    .LoadPlanetSimulation(data.planetName);
            });
        }
    }

    public void HidePlanetInfo()
    {
        if (planetInfoPanel != null)
            planetInfoPanel.SetActive(false);
    }

    public void ShowPlanetHoverLabel(
        string name, Vector3 worldPos)
    {
        if (hoverLabel == null) return;

        hoverLabel.SetActive(true);

        if (hoverLabelText != null)
            hoverLabelText.text = name;

        Vector3 screenPos = Camera.main
            .WorldToScreenPoint(
            worldPos + Vector3.up * 2f);

        hoverLabel.transform.position = screenPos;
    }

    public void HidePlanetHoverLabel()
    {
        if (hoverLabel != null)
            hoverLabel.SetActive(false);
    }
}