using UnityEngine;
using UnityEngine.UI;

public class ResizePlank : MonoBehaviour
{
    // Change dimension of changeable plank in the middle

    public Slider lengthSlider;
    public Slider widthSlider;
    public Slider heightSlider;
    public GameObject additionalPlank;  // plank used for height. it is second gameobject 
    public GameObject stairCollider;    // invisible collider used for player to be able to go up on the plank. little steps to climb on.

    float defScale;

    // Parameters of the middle plank
    // Length
    float defLength;
    float length;

    // Width
    float width;
    float widthOffset;
    float widthMultiplier;

    // Height
    float defHeight;
    float height;
    float adWidthOffset;    // How much narrower is the plank, which will be higher (clipping reason)
    float adWidthApplyOffset;   // How much longer does plank need to be, to see height difference

    // Start is called before the first frame update
    void Start()
    {
        // Add listeners for sliders
        lengthSlider.onValueChanged.AddListener(delegate {
            LengthSliderOnValueChanged(lengthSlider);
        });
        length = this.transform.localScale.x;

        widthSlider.onValueChanged.AddListener(delegate {
            WidthSliderOnValueChanged(widthSlider);
        });
        width = this.transform.localScale.y;
        widthOffset = 10.0f;
        widthMultiplier = 3.0f;

        heightSlider.onValueChanged.AddListener(delegate {
            HeightSliderOnValueChanged(heightSlider);
        });
        height = additionalPlank.transform.localScale.z;

        // set some default values for calculating correct size in-game compared to real-life & correct rescaling
        defScale = 100.0f;
        defLength = 1.585408f;
        defHeight = 95.0f;
        adWidthOffset = 0.5f;
        adWidthApplyOffset = 1.0f;
    }

    void LengthSliderOnValueChanged(Slider slider)  // listener for lenght slider
    {
        // Change length and then call resize functions
        length = defScale + (slider.value) / defLength;
        RescalePlank();
        RescaleAdditionalPlank();
    }

    void WidthSliderOnValueChanged(Slider slider)  // listener for width slider
    {
        // Change width and then call resize functions
        width = widthOffset + slider.value * widthMultiplier;
        RescalePlank();
        RescaleAdditionalPlank();
    }

    void HeightSliderOnValueChanged(Slider slider)  // listener for height slider
    {
        // Change height and then call resize functions
        height = defHeight + (slider.value) / defLength * 100.0f;
        RescalePlank();
        RescaleAdditionalPlank();
    }

    void RescalePlank() // Rescale main plank (used for length and width)
    {
        this.transform.localScale = new Vector3(length, width, defScale);
    }
    void RescaleAdditionalPlank()   // Rescale additional plank used to se increased height of the plank
    {
        float appliedHeight = height;
        if (length < defScale + adWidthApplyOffset) appliedHeight = defHeight;  // if length of the plank is not great enough, dont increase height of the plank
        additionalPlank.transform.localScale = new Vector3(length - defScale, width - adWidthOffset, appliedHeight);    // resize additional plank
        stairCollider.transform.localScale = new Vector3(stairCollider.transform.localScale.x, stairCollider.transform.localScale.y, (appliedHeight-defHeight)*0.37f);  // resize invisible stair collider
    }
}
