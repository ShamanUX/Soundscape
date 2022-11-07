using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParameterMelody : SetFMODParameter
{

    //The cube used to hit the synth plates
    public GameObject synthCube;

    FMOD.Studio.EventInstance instance;

    private void Awake()
    {
        synthCube = GameObject.Find("Synth Cube");
    }

    // Start is called before the first frame update
    void Start()
    {
        
        instance = targetEventEmitter.EventInstance;
    }

    // Update is called once per frame
    void Update()
    {

        //If synth cube is disabled, stop playing all sounds
        if ( synthCube.activeSelf == false)
        {
            instance.setParameterByName(parameterName, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        instance.setParameterByName(parameterName, 1);
    }

    private void OnTriggerExit(Collider other)
    {
        instance.setParameterByName(parameterName, 0);

    }
}
