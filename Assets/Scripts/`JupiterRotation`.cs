using UnityEngine;

public class JupiterRotation : MonoBehaviour
{
    [Header("Jupiter Rotation")]
    public float rotationPeriodHours = 10f;
    public float speedMultiplier = 500f;

    private float degreesPerSecond;

    void Start()
    {
        float realDeg = 360f / (rotationPeriodHours * 3600f);
        degreesPerSecond = realDeg * speedMultiplier;
    }

    void Update()
    {
        transform.Rotate(
            Vector3.up * degreesPerSecond * Time.deltaTime
        );
    }
}