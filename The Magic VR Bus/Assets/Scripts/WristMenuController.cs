using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WristMenuController : MonoBehaviour
{
    public GameObject wristUI;
    public bool isUIActive = true;


    // Start is called before the first frame update
    void Start()
    {
        DisplayWristUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuPressed(InputAction.CallbackContext context)
    {
        if(context.performed) DisplayWristUI();
    }

    public void DisplayWristUI()
    {
        if(isUIActive)
        {
            wristUI.SetActive(false);
            isUIActive = false;
        }
        else
        {
            wristUI.SetActive(true);
            isUIActive = true;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("Level 1 Scene");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Level 2 Scene");
    }

    public void LoadSceneDevPlayground()
    {
        SceneManager.LoadScene("Dev Playground (Internal Use Only)");
    }
}
