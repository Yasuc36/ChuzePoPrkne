using UnityEngine;

public class SetCameraYPosition : MonoBehaviour
{
    // Sets camera height position. Offset from feet (ground) to eyes (head).

    public Transform cameraTransform;

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(0, cameraTransform.localPosition.y, 0);  // Set Y as Y position of headset
    }
}
