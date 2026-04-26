using UnityEngine;

public class SpeedOfLight : MonoBehaviour
{
    public Transform sunTransform;
    public float lightSpeed = 50f;
    public float maxRadius = 200f;
    public GameObject pulsePrefab;
    public float pulseInterval = 3f;

    private float _timer = 0f;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= pulseInterval)
        {
            _timer = 0f;
            SpawnPulse();
        }
    }

    void SpawnPulse()
    {
        GameObject pulse = Instantiate(
            pulsePrefab,
            sunTransform.position,
            Quaternion.identity);

        PulseRing ring = pulse
            .GetComponent<PulseRing>();
        if (ring != null)
        {
            ring.speed = lightSpeed;
            ring.maxRadius = maxRadius;
        }
    }
}

public class PulseRing : MonoBehaviour
{
    public float speed = 50f;
    public float maxRadius = 200f;
    private float _radius = 0f;
    private LineRenderer _line;

    void Start()
    {
        _line = gameObject
            .AddComponent<LineRenderer>();
        _line.positionCount = 64;
        _line.startWidth = 0.3f;
        _line.endWidth = 0.3f;
        _line.loop = true;

        Material mat = new Material(
            Shader.Find(
            "Universal Render Pipeline/Unlit"));
        mat.color = new Color(1f, 0.9f, 0.3f, 0.8f);
        _line.material = mat;
    }

    void Update()
    {
        _radius += speed * Time.deltaTime;

        // Draw expanding ring
        for (int i = 0; i < 64; i++)
        {
            float angle = (i / 64f) * Mathf.PI * 2f;
            _line.SetPosition(i, new Vector3(
                Mathf.Cos(angle) * _radius,
                0,
                Mathf.Sin(angle) * _radius));
        }

        // Fade out as it expands
        float alpha = 1f - (_radius / maxRadius);
        Color c = _line.material.color;
        c.a = alpha;
        _line.material.color = c;

        if (_radius >= maxRadius)
            Destroy(gameObject);
    }
}