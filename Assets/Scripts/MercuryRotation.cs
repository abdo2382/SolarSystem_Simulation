using UnityEngine;

public class MercuryRotation : MonoBehaviour
{
    // Mercury rotates once every 58.6 Earth days — extremely slow
    public float rotationSpeed = 0.3f;

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}