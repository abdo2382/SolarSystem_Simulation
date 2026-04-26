using UnityEngine;
using System.Collections;
using TMPro;

public class MercuryFlyIn : MonoBehaviour
{
    [Header("Camera Positions")]
    public Transform outsidePosition;
    public Transform crustPosition;
    public Transform mantlePosition;
    public Transform corePosition;

    [Header("Layers")]
    public GameObject crust;
    public GameObject mantle;
    public GameObject core;

    [Header("UI")]
    public TextMeshProUGUI layerNameText;
    public TextMeshProUGUI instructionText;
    public TextMeshProUGUI layerInfoText;

    [Header("Settings")]
    public float flySpeed = 2f;

    private int currentLayer = 0;
    private bool isFlying = false;

    void Start()
    {
        crust.SetActive(false);
        mantle.SetActive(false);
        core.SetActive(false);

        if (layerNameText != null) layerNameText.text = "MERCURY";
        if (instructionText != null) instructionText.text = "PRESS SPACE TO FLY INSIDE";
        if (layerInfoText != null) layerInfoText.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFlying)
        {
            if (currentLayer == 0)
                StartCoroutine(FlyTo(crustPosition, 1,
                    "CRUST",
                    "PRESS SPACE TO GO DEEPER",
                    "Thickness: ~300 km\nTemp: -180°C to 430°C\nComposition: Silicate rock\nHeavily cratered surface"));

            else if (currentLayer == 1)
                StartCoroutine(FlyTo(mantlePosition, 2,
                    "MANTLE",
                    "PRESS SPACE TO REACH THE CORE",
                    "Thickness: ~400 km\nTemp: ~1000°C\nComposition: Silicate rock\nThin compared to other planets"));

            else if (currentLayer == 2)
                StartCoroutine(FlyTo(corePosition, 3,
                    "CORE",
                    "PRESS SPACE TO EXIT",
                    "Size: 85% of Mercury's radius\nTemp: ~2000°C\nComposition: Iron & Nickel\nLargest core ratio in Solar System"));

            else if (currentLayer == 3)
                StartCoroutine(FlyTo(outsidePosition, 0,
                    "MERCURY",
                    "PRESS SPACE TO FLY INSIDE",
                    "Smallest planet in Solar System\nDiameter: 4,879 km\nNo atmosphere\nClosest planet to the Sun"));
        }
    }

    IEnumerator FlyTo(Transform target, int nextLayer,
        string layerName, string instruction, string info)
    {
        if (target == null) { isFlying = false; yield break; }

        isFlying = true;

        yield return null;

        if (nextLayer == 1)
        {
            crust.SetActive(true);
            mantle.SetActive(false);
            core.SetActive(false);
        }
        else if (nextLayer == 2)
        {
            crust.SetActive(false);
            mantle.SetActive(true);
            core.SetActive(false);
        }
        else if (nextLayer == 3)
        {
            crust.SetActive(false);
            mantle.SetActive(false);
            core.SetActive(true);
        }
        else if (nextLayer == 0)
        {
            crust.SetActive(false);
            mantle.SetActive(false);
            core.SetActive(false);
        }

        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * flySpeed;
            transform.position = Vector3.Lerp(startPos, target.position, t);
            transform.rotation = Quaternion.Lerp(startRot, target.rotation, t);
            yield return null;
        }

        transform.position = target.position;
        transform.rotation = target.rotation;
        currentLayer = nextLayer;
        isFlying = false;

        if (layerNameText != null) layerNameText.text = layerName;
        if (instructionText != null) instructionText.text = instruction;
        if (layerInfoText != null) layerInfoText.text = info;
    }
}