using UnityEngine;

public class SetControllerPosition : MonoBehaviour
{
    // Adjust position of controllers

    public GameObject center;

    // Update is called once per frame
    void Update()
    {
        // Controllers need to move 2 ways: relative to player and relative to scene
        // Movement of controllers themself is dealt with by XR toolkit for each controller individually
        // Encapsulating object (this one) takes care of position of controllers in Scene (move with player center)
        this.transform.localPosition = new Vector3(center.transform.localPosition.x, center.transform.localPosition.y, center.transform.localPosition.z);
    }
}
