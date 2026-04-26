using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.InputSystem;

public class ZoomInLayers : MonoBehaviour
{
    [Header("Layer Objects")]
    public GameObject crust;
    public GameObject mantle;
    public GameObject core;

    [Header("UI Text")]
    public TextMeshProUGUI layerText;
    public TextMeshProUGUI instructText;
    public TextMeshProUGUI factText;

    [Header("Settings")]
    public float animSpeed = 1.5f;

    private int currentStep = 0;
    private bool isAnimating = false;

    void Start()
    {
        crust.SetActive(true);
        mantle.SetActive(true);
        core.SetActive(true);

        layerText.text = "MERCURY";
        instructText.text = "PRESS SPACE TO EXPLORE";
        factText.text = "";
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame
            && !isAnimating)
        {
            if (currentStep == 0)
            {
                // Remove crust show mantle
                StartCoroutine(ScaleDown(crust, 1,
                "CRUST",
                "Rocky silicate surface\n300km thick",
                "PRESS SPACE TO GO DEEPER"));
            }
            else if (currentStep == 1)
            {
                // Remove mantle show core
                StartCoroutine(ScaleDown(mantle, 2,
                "MANTLE",
                "Silicate rock layer\n400km thick",
                "PRESS SPACE TO GO DEEPER"));
            }
            else if (currentStep == 2)
            {
                // Show core
                currentStep = 3;
                layerText.text = "CORE";
                factText.text =
                "Iron and Nickel\n42% of Mercury";
                instructText.text =
                "PRESS SPACE TO EXIT";
            }
            else if (currentStep == 3)
            {
                // Reset everything
                StartCoroutine(ResetAll());
            }
        }
    }

    IEnumerator ScaleDown(GameObject layer,
    int nextStep, string name,
    string fact, string instruct)
    {
        isAnimating = true;
        Vector3 startScale = layer.transform.localScale;
        Vector3 endScale = Vector3.zero;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * animSpeed;
            layer.transform.localScale = Vector3.Lerp(
                startScale, endScale, t);
            yield return null;
        }

        layer.SetActive(false);
        layer.transform.localScale = startScale;
        currentStep = nextStep;
        isAnimating = false;

        layerText.text = name;
        factText.text = fact;
        instructText.text = instruct;
    }

    IEnumerator ResetAll()
    {
        isAnimating = true;

        // Bring everything back
        crust.SetActive(true);
        mantle.SetActive(true);
        core.SetActive(true);

        // Reset scales
        crust.transform.localScale =
        new Vector3(10, 10, 10);
        mantle.transform.localScale =
        new Vector3(7, 7, 7);
        core.transform.localScale =
        new Vector3(4, 4, 4);

        currentStep = 0;
        isAnimating = false;

        layerText.text = "MERCURY";
        factText.text = "";
        instructText.text = "PRESS SPACE TO EXPLORE";

        yield return null;
    }
}