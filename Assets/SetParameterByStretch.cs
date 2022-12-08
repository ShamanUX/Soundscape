using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParameterByStretch : MonoBehaviour
{
    public static float initialVolume = 5;
    float initialScale;
    float newVolume;

    FMOD.Studio.EventInstance instance;

    UnityEngine.UI.Text volumeIndicator;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale.magnitude;
        volumeIndicator = GameObject.Find("Volume indicator").GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.isValid())
        {
            //Set volume parameter based on Stretch cube size
            float volume = initialVolume * (transform.localScale.magnitude / initialScale);
            instance.setParameterByName("volume", volume);
            
            instance.getParameterByName("volume", out newVolume);
            volumeIndicator.text = "Volume: " + newVolume;
        }
    }

    // OnTriggerEnter runs when this stretch cube enters the PlayCube area.
    private void OnTriggerEnter(Collider other)
    {
        FMODUnity.StudioEventEmitter emitter = other.GetComponent<FMODUnity.StudioEventEmitter>();

        instance = emitter.EventInstance;

        gameObject.GetComponent<SetLPFilterParameter>().UpdateInstance();

    }
}
