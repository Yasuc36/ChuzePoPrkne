using UnityEngine;

public class SoundFall : MonoBehaviour
{
    // Takes care of sound when falling

    public AudioSource fallSound;
    public AudioSource impactSound;
    public float fallSpeed; // speed limit when Y movement should be considered as fall
    public float stopSpeed; // speed limit when Y movement is no longer considered as fall
    float prevY;    // Used to save last Y position of player
    bool falling;

    // Start is called before the first frame update
    void Start()
    {
        prevY = this.transform.localPosition.y;
        falling = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!falling)   // When player is not falling, look for when to start the fall
        {
            if (prevY > this.transform.localPosition.y + fallSpeed) // If difference of current and previous Y coordínate of player is bigger than fallSpeed, player is falling
            {
                fallSound.Play();
                falling = true;
            }
        }
        else   // When player is falling, look for when to stop the fall
        {
            if (prevY < this.transform.localPosition.y + stopSpeed) // If difference of current and previous Y coordínate of player is smaller than stopSpeed, player is not falling anymore
            {
                impactSound.Play();
                fallSound.Stop();
                falling = false;
            }
        }
        prevY = this.transform.localPosition.y; //  save current position to prevY -> will be used to compare with new Y position
    }
}
