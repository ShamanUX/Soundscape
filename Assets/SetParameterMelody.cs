using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParameterMelody : SetFMODParameter
{

    FMOD.Studio.EventInstance instance; 

    // Start is called before the first frame update
    void Start()
    {
        instance = targetEventEmitter.EventInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
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
