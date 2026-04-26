using UnityEngine;

public class MoonOrbit : MonoBehaviour
{
    [Header("Orbit Settings")]
    public Transform orbitCenter;
    public float orbitRadius = 35f;
    public float orbitSpeed = 20f;
    public float orbitTiltDeg = 0f;
    public float startAngle = 0f;

    private float angle;

    void Start() { angle = startAngle; }

    void Update()
    {
        angle += orbitSpeed * Time.deltaTime;

        float rad = angle * Mathf.Deg2Rad;
        float tilt = orbitTiltDeg * Mathf.Deg2Rad;

        float x = orbitRadius * Mathf.Cos(rad);
        float y = orbitRadius
                  * Mathf.Sin(rad) * Mathf.Sin(tilt);
        float z = orbitRadius
                  * Mathf.Sin(rad) * Mathf.Cos(tilt);

        Vector3 c = orbitCenter != null
                    ? orbitCenter.position
                    : Vector3.zero;

        transform.position = c + new Vector3(x, y, z);
    }
}