using UnityEngine;
using UnityEngine.InputSystem;

public class InputLeftHand : MonoBehaviour
{
    // Takes care of inputs on left controller

    public InputActionProperty menuPress;
    public Canvas menuCanvas;

    // Update is called once per frame
    void Update()
    {
        if (menuPress.action.triggered) menuCanvas.enabled = !menuCanvas.enabled;   // if menu button is pressed, toggle UI
    }
}
