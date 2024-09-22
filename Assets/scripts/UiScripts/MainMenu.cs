using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool continueGame = false;
    public bool Startgame = false;

    public static MainMenu instance;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        instance = this;
    }
    public void OnContinueButton()
    {
        Debug.Log("Continue");
        continueGame = true;
        SceneManager.LoadScene("Town");
    }
    public void OnStartButton()
    {
        Debug.Log("Start");
        Startgame = true;
        SceneManager.LoadScene("Town");
    }
    public void QuitButton()
    {
        Debug.Log("Quiet...............");
        Application.Quit();
    }
}
