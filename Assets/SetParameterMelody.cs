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
        
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    private void OnEnable()
    {
        instance = targetEventEmitter.EventInstance;
    }

    // Update is called once per frame
    void Update()
    {
        float isNoteActive;
        instance.getParameterByName(parameterName, out isNoteActive); ;

        if (isNoteActive == 1)
        {
            gameObject.GetComponent<AnimateColour>().HitTriggered();
        }

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
