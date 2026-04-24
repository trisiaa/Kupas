using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene(1); // load scene index 1 (ingame)
    }

    public void ButtonExit()
    {
        Application.Quit(); // keluar game
    }
}