using UnityEngine;
using UnityEngine.UI;

public class SwitchLights : MonoBehaviour
{
    // Takes care of swithcnig between night and day lightning (also includes corresponding sounds)

    GameObject[] lights;    // sources of lights. in this case: Lamp lights
    public GameObject sun;
    public Toggle isNightToggle;

    public Material daySkybox;
    public Color dayFogColor;
    public GameObject dayReflectionProbes;
    public float dayEnviromentIntensity;    // Ambient light intensity
    public AudioSource daySound;
    float daySoundVolume;

    public Material nightSkybox;
    public Color nightFogColor;
    public GameObject nightReflectionProbes;
    public float nightEnviromentIntensity;  // Ambient light intensity
    public AudioSource nightSound;
    float nightSoundVolume;

    // Start is called before the first frame update
    void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("LampLights");   // Add all lamp lights to the array
        isNightToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(isNightToggle);
        });
        daySoundVolume = daySound.volume;
        nightSoundVolume = nightSound.volume;
        nightSound.volume = 0.0f;   // starting state is day, hence turn the night volume to 0
    }

    // Called when toggle value is changed
    void ToggleValueChanged(Toggle change)
    {
        foreach (GameObject light in lights)    // switch on/off sources of lights
            light.GetComponent<Light>().enabled = isNightToggle.isOn;
        sun.SetActive(!isNightToggle.isOn);

        if (isNightToggle.isOn) // Setup lighting (fog color, ambient intensity, skybox...) and sound for night
        {
            RenderSettings.skybox = nightSkybox;
            RenderSettings.fogColor = nightFogColor;
            RenderSettings.ambientIntensity = nightEnviromentIntensity;
            dayReflectionProbes.SetActive(false);
            nightReflectionProbes.SetActive(true);
            nightSound.volume = nightSoundVolume;
            daySound.volume = 0.0f;
        }
        else  // Setup lighting (fog color, ambient intensity, skybox...) and sound for day
        {
            RenderSettings.skybox = daySkybox;
            RenderSettings.fogColor = dayFogColor;
            RenderSettings.ambientIntensity = dayEnviromentIntensity;
            dayReflectionProbes.SetActive(true);
            nightReflectionProbes.SetActive(false);
            nightSound.volume = 0.0f;
            daySound.volume = daySoundVolume;
        }
    }
}
