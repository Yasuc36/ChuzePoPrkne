using UnityEngine;

public class SetRigPosition : MonoBehaviour
{
    // Takes control of changing X, Z position of the player rig.
    // Since there are 2 types of movement (movement of controllers and headset + in-game movement of character), some calculations are necessary to correct move the player
    // X,Y,Z of headset is fixed by how XR toolkit gets position from headset. This script calculates additional changes to player by managing X and Z axis using headset real X and Z position.

    private Vector3 startingPosition;
    public Transform cameraTransform;   // Transform of game object, that gets headset coordinations from real movement

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = new Vector3(this.transform.localPosition.x, 0, this.transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Get X and Z position of headset and apply them to player rig (player camera position is not changed by headset position directly. It is child of this gameobject, so it takes position this way.)
        this.transform.localPosition = startingPosition + new Vector3(cameraTransform.localPosition.x, this.transform.localPosition.y, cameraTransform.localPosition.z);
    }
}
