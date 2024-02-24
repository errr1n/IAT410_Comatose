using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //sets cursor invisible
        Cursor.visible = false;
        //sets cursor to locked
        Cursor.lockState = CursorLockMode.Locked;
        //loads next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        //quits game
        Application.Quit();
    }
}
