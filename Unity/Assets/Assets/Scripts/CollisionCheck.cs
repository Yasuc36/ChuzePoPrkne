using UnityEngine;
using UnityEngine.UI;

public class CollisionCheck : MonoBehaviour
{
    public SpriteRenderer shadow;
    public Toggle toggleShadow;

    int collisionCount; // how many objects are in collision with this one

    private void Start()
    {
        toggleShadow.onValueChanged.AddListener(delegate {
            ToggleValueChanged(toggleShadow);
        });
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionCount++;
        ToggleShadow();
    }
    private void OnCollisionExit(Collision collision)
    {
        collisionCount--;
        ToggleShadow();
    }

    void ToggleValueChanged(Toggle toggle)  // listens for toggle value change
    {
        ToggleShadow();
    }

    void ToggleShadow()
    {
        // If player is colliding, show shadow underneath the player to indicate precise position
        if (collisionCount > 0 && toggleShadow.isOn) shadow.enabled = true;
        else shadow.enabled = false;
    }
}
