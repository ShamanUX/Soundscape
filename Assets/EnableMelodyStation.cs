using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMelodyStation : MonoBehaviour
{


    public GameObject melodyStation;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        melodyStation.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        melodyStation.SetActive(false);
    }

}
