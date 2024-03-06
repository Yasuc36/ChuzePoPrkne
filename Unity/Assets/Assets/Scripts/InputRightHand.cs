using UnityEngine;
using UnityEngine.InputSystem;

public class InputRightHand : MonoBehaviour
{
    // Takes control of input on right controller

    public InputActionProperty triggerPress;    // Right controler trigger (index finger)

    // Update is called once per frame
    void Update()
    {
        float triggerValue = triggerPress.action.ReadValue<float>();    // Value of how much is the right trigger pressed <0.00000; 1.00000>
    }
}
