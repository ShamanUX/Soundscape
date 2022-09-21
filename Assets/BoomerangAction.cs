using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoomerangAction : MonoBehaviour
{

    public InputActionReference boomerangReference;

    private void Awake()
    {
        boomerangReference.action.started += Toggle;
    }

    private void OnDestroy()
    {
        boomerangReference.action.started += Toggle;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        Debug.Log("primary righthand button pressed");
        
        // Etsii pelaajan position, ja asettaa palikan pelaajan eteen

        GameObject player = GameObject.Find("XR Origin");
        Vector3 playerPosition = player.transform.position;

        Vector3 yOffset = new Vector3(0, 2, 0);
        gameObject.transform.position = playerPosition + player.transform.forward + yOffset;
    }


}
