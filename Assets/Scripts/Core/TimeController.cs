using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    public static float TimeScale = 1f;

    [Header("UI")]
    public Slider timeSlider;
    public TextMeshProUGUI timeLabel;

    void Start()
    {
        TimeScale = 1f;
        timeSlider.value = 1f;

        if (timeSlider != null)
        {
            timeSlider.minValue = 0f;
            timeSlider.maxValue = 10f;
            timeSlider.value = 1f;
            timeSlider.onValueChanged
                .AddListener(OnSliderChanged);
        }

        if (timeLabel != null)
            timeLabel.text = "> Real Time";
    }

    void OnSliderChanged(float value)
    {
        TimeScale = value;

        if (timeLabel == null) return;

        if (value == 0)
            timeLabel.text = "II Paused";
        else if (value <= 1f)
            timeLabel.text = "> Real Time";
        else
            timeLabel.text = ">> x"
                + value.ToString("F1");
    }

    public void PauseTime()
    {
        if (timeSlider != null)
            timeSlider.value = 0f;
    }

    public void NormalTime()
    {
        if (timeSlider != null)
            timeSlider.value = 1f;
    }

    public void FastTime()
    {
        if (timeSlider != null)
            timeSlider.value = 5f;
    }
}