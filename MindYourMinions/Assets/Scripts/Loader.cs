using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

    private void Start()
    {
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        Debug.Log("Trying to press button");

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        Debug.Log("Trying to press button");
        SceneManager.LoadScene(0);
    }

    public void LoadInstructions()
    {
        Time.timeScale = 1;
        Debug.Log("Trying to press button");
        SceneManager.LoadScene(1);
    }

    public void LoadCredits()
    {
        Time.timeScale = 1;
        Debug.Log("Trying to press button");
        SceneManager.LoadScene(4);
    }

    public void LoadLevel1()
    {
        Time.timeScale = 1;
        Debug.Log("Trying to press button");
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
