using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject levelSelectionPanel;

    public void ButtonPlay()
    {
        mainMenuPanel.SetActive(false);
        levelSelectionPanel.SetActive(true);
    }

    public void ButtonCloseLevel()
    {
        levelSelectionPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}