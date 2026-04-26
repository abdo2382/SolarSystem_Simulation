using UnityEngine;

public class SolarSystemManager : MonoBehaviour
{
    public static SolarSystemManager Instance;

    [Header("References")]
    public CameraController camController;
    public UIManager uiManager;
    public AudioManager audioManager;

    [Header("State")]
    public bool isFocused = false;
    private PlanetClickHandler _currentPlanet;

    void Awake()
    {
        Instance = this;
    }

    public void FocusPlanet(PlanetClickHandler planet)
    {
        if (planet == null) return;

        _currentPlanet = planet;
        isFocused = true;

        if (camController != null)
            camController.FocusOn(
                planet.transform, planet.focusDistance);

        if (uiManager != null)
            uiManager.ShowPlanetInfo(planet.data);

        if (audioManager != null)
            audioManager.PlayPlanetSound(
                planet.data.planetAmbientSound,
                planet.data.soundVolume);
    }

    public void Unfocus()
    {
        isFocused = false;

        if (camController != null)
            camController.ReturnToSolarView();

        if (uiManager != null)
            uiManager.HidePlanetInfo();

        if (audioManager != null)
            audioManager.FadeBackgroundMusic();
    }
}