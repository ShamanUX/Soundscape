using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public InputActionReference pauseReference;

    public GameObject wristUI;
    public bool activeWristUI = false;


    // Start is called before the first frame update
    void Start()
    {
        wristUI.SetActive(false);

    }


    private void Awake()
    {
        pauseReference.action.performed += DisplaywristUI;
    }

    private void OnDestroy()
    {
        pauseReference.action.performed -= DisplaywristUI;
    }


    public void DisplaywristUI(InputAction.CallbackContext context)
    {
        if (activeWristUI)
        {
            wristUI.SetActive(false);
            activeWristUI = false;
        }
        else if (!activeWristUI)
        {
            wristUI.SetActive(true);
            activeWristUI = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
