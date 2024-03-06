using UnityEngine;

public class SoundTop : MonoBehaviour
{
    // Takes care of corrent position of audio source for winds at the high platform

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Player.transform.position;    // At start, set the audio source right at the player position
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z); // move the sound with player, but ignore Y axis (height)
    }
}
