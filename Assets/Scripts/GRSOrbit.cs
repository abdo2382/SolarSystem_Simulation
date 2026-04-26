using UnityEngine;

public class GRSOrbit : MonoBehaviour
{
    [Header("GRS Settings")]
    public Transform jupiterCenter;
    public float orbitSpeed = 1.5f;
    public float surfaceRadius = 10.3f;
    public float latitudeDegrees = -23f;

    private float angle = 0f;

    void Update()
    {
        angle += orbitSpeed * Time.deltaTime;

        float a = angle * Mathf.Deg2Rad;
        float lat = latitudeDegrees * Mathf.Deg2Rad;

        float x = surfaceRadius
                  * Mathf.Cos(lat) * Mathf.Cos(a);
        float y = surfaceRadius * Mathf.Sin(lat);
        float z = surfaceRadius
                  * Mathf.Cos(lat) * Mathf.Sin(a);

        Vector3 c = jupiterCenter != null
                    ? jupiterCenter.position
                    : Vector3.zero;

        transform.position = c + new Vector3(x, y, z);

        Vector3 outward = transform.position - c;
        transform.rotation =
            Quaternion.LookRotation(outward) *
            Quaternion.Euler(90f, 0f, 0f);
    }
}