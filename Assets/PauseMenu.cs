using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject wristUI;
    public bool activeWristUI = true;


    // Start is called before the first frame update
    void Start()
    {
        DisplaywristUI();

    }

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if (context.performed) DisplaywristUI();
    }

    public void DisplaywristUI()
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
