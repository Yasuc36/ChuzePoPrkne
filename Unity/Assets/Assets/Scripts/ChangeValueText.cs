using UnityEngine;
using UnityEngine.UI;

public class ChangeValueText : MonoBehaviour
{
    // Change label text depending on the label value

    public Slider sourceSlider;
    public Text sourceLabel;

    // Start is called before the first frame update
    void Start()
    {
        sourceSlider.onValueChanged.AddListener(delegate {
            SliderValueChanged(sourceSlider);
        });
        changeText(sourceLabel, sourceSlider.value);
    }

    void SliderValueChanged(Slider slider)  // listens for slider change
    {
        changeText(sourceLabel, slider.value);
    }

    void changeText(Text text, float value) // Change text according to the value
    {
        text.text = string.Format("{0} cm", value.ToString("0.0"));
    }
}
