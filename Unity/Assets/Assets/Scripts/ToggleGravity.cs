using UnityEngine;
using UnityEngine.UI;

public class ToggleGravity : MonoBehaviour
{
    // Switches off and on the gravity force of player's rigid body -> takes care of falling down

    public Toggle toggleGravity;
    public Rigidbody rigidbodyPlayer;

    // Start is called before the first frame update
    void Start()
    {
        toggleGravity.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggleGravity);
        });
    }

    void ToggleValueChanged(Toggle toggle)  // listener for toggle value changed
    {
        rigidbodyPlayer.useGravity = toggle.isOn;
    }
}
