using UnityEngine;

public class LightningFlash : MonoBehaviour
{
    [Header("Lightning Settings")]
    public Light[] lightningLights;
    public float minDelay = 0.3f;
    public float maxDelay = 4f;
    public float flashDuration = 0.06f;
    public float maxIntensity = 6f;
    private float nextFlash;
    private bool flashing;
    private float flashEnd;
    private Light activeLight;

    void Start() { Schedule(); }

    void Update()
    {
        if (flashing)
        {
            if (Time.time >= flashEnd)
            {
                if (activeLight != null)
                    activeLight.intensity = 0f;
                flashing = false;
                Schedule();
            }
        }
        else if (Time.time >= nextFlash)
        {
            Flash();
        }
    }

    void Flash()
    {
        if (lightningLights.Length == 0) return;
        activeLight = lightningLights[
            Random.Range(0, lightningLights.Length)];
        activeLight.intensity =
            Random.Range(maxIntensity * 0.4f, maxIntensity);
        flashing = true;
        flashEnd = Time.time + flashDuration;
    }

    void Schedule()
    {
        nextFlash = Time.time +
            Random.Range(minDelay, maxDelay);
    }
}