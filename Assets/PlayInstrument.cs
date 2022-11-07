using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayInstrument : MonoBehaviour
{

    public InputActionReference playInstrumentReference;

    private void Awake()
    {
        playInstrumentReference.action.started += Hold;
        playInstrumentReference.action.canceled += Release;
    }

    private void OnDestroy()
    {
        playInstrumentReference.action.started += Hold;
        playInstrumentReference.action.canceled += Release;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // When button hold is started, enable the synthCube
    private void Hold(InputAction.CallbackContext context)
    {
        Debug.Log("hold started");
        gameObject.SetActive(true);
    }
    
    private void Release(InputAction.CallbackContext context)
    {
        Debug.Log("hold released");
        gameObject.SetActive(false);
    }
    

}

