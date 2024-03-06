using UnityEngine;
using UnityEngine.UI;

public class SwitchSounds : MonoBehaviour
{
    // Takes care of toggling on and off sounds

    public GameObject sounds;
    public Toggle turnOffAudioToggle;

    // Start is called before the first frame update
    void Start()
    {
        turnOffAudioToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(turnOffAudioToggle);
        });
    }

    void ToggleValueChanged(Toggle toggle)  // listens for toggle vlaue change
    {
        sounds.SetActive(!toggle.isOn);
    }
}
