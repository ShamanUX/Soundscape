using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PitchByPosition : MonoBehaviour
{
    public AudioSource audioSource;
    AudioMixer mixer;
    
    // Start is called before the first frame update

    
    void Start()
    {
        mixer = audioSource.outputAudioMixerGroup.audioMixer;
    }

    // Update is called once per frame
    void Update()
    {
        //determines a value for the music's pitch based on the cube's position on z-axis
        float pitchPercent = 1 + gameObject.transform.position.z / 10;

        // sets the pitch value to the "PitchPercent" exposed variable (from audio mixer)
        mixer.SetFloat("PitchPercent", pitchPercent);
    }


}
