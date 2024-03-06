using UnityEngine;
using UnityEngine.UI;

public class ReturnToSpawn : MonoBehaviour
{
    // Resets player to starting position and rotation (and adjust rotation by real life rotation)

    // player and rig gameobject are both used for complete movement, so their position needs to be reset
    public GameObject player;
    public GameObject rig;
    public GameObject cameraRotation;
    public Button resetButton;
    Vector3 playerStartPosition;
    Vector3 playerStartRotation;

    void Start()
    {
        playerStartPosition = player.transform.position;
        playerStartRotation = rig.transform.localRotation.eulerAngles;
        resetButton.onClick.AddListener(delegate {
            ResetButtonOnClick(resetButton);
        });
    }

    void ResetButtonOnClick(Button ResetButton) // listens for reset button to be pressed
    {
        player.transform.position = playerStartPosition;

        Vector3 newAngle = playerStartRotation;

        newAngle.y -= cameraRotation.transform.localRotation.eulerAngles.y; // adjust y rotation by current headset direction -> face forward
        Quaternion newRotation = Quaternion.Euler(newAngle);
        rig.transform.rotation = newRotation;
    }
}
