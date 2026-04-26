using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ExplodeView : MonoBehaviour
{
    public GameObject crust;
    public GameObject mantle;
    public GameObject core;
    public TextMeshProUGUI layerText;
    public TextMeshProUGUI instructText;

    private bool isExploded = false;

    // Original positions
    private Vector3 crustTarget;
    private Vector3 mantleTarget;
    private Vector3 coreTarget;

    void Start()
    {
        crustTarget = crust.transform.position;
        mantleTarget = mantle.transform.position;
        coreTarget = core.transform.position;

        layerText.text = "MERCURY INTERIOR";
        instructText.text = "PRESS SPACE TO EXPLODE VIEW";
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!isExploded)
            {
                // Explode layers apart
                crustTarget = new Vector3(18, 0, 0);
                mantleTarget = new Vector3(0, 0, 0);
                coreTarget = new Vector3(-18, 0, 0);

                layerText.text = "CRUST | MANTLE | CORE";
                instructText.text =
                "PRESS SPACE TO REASSEMBLE";
                isExploded = true;
            }
            else
            {
                // Bring back together
                crustTarget = Vector3.zero;
                mantleTarget = Vector3.zero;
                coreTarget = Vector3.zero;

                layerText.text = "MERCURY INTERIOR";
                instructText.text =
                "PRESS SPACE TO EXPLODE VIEW";
                isExploded = false;
            }
        }

        // Smoothly move each layer
        crust.transform.position = Vector3.Lerp(
            crust.transform.position, crustTarget,
            Time.deltaTime * 2f);

        mantle.transform.position = Vector3.Lerp(
            mantle.transform.position, mantleTarget,
            Time.deltaTime * 2f);

        core.transform.position = Vector3.Lerp(
            core.transform.position, coreTarget,
            Time.deltaTime * 2f);
    }
}