using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuNoPause : MonoBehaviour {

    public void LoadMainMenu()
    {
        Debug.Log("Trying to press button");
        SceneManager.LoadScene(0);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }

}
