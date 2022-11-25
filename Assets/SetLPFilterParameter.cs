using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLPFilterParameter : SetFMODParameter
{

    public GameObject filterPillow;


    FMOD.Studio.EventInstance instance;



    public float distanceModifier = 20;

    // Start is called before the first frame update
    void Start()
    {
        parameterName = "LPFilter";

        instance = targetEventEmitter.EventInstance;
    }

    // Update is called once per frame
    void Update()
    {
        float pillowDistance = Vector3.Distance(filterPillow.transform.position, transform.position);

        SetLPFilterByDistance(pillowDistance);

    }

    void SetLPFilterByDistance(float pillowDistance)
    {
       

        float valueByDistance;

        valueByDistance = pillowDistance * distanceModifier;

        // LPFilter parameter values range from 0 to 50, where 50 
        // means no effect and 0 means most effect of LPFilter.
        instance.setParameterByName(parameterName, valueByDistance);
        
    }

    // called when EventInstance is restarted in another script
    public void UpdateInstance()
    {
        instance = targetEventEmitter.EventInstance;
    }

}
