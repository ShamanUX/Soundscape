using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODloudness : MonoBehaviour
{

    public StudioEventEmitter emitter;

    public EventInstance instance;

    float volume;


    // Start is called before the first frame update
    void Start()
    {
        instance = emitter.EventInstance;
    }

    // Update is called once per frame
    void Update()
    {
        instance.getVolume(out float volume);
    }
}
