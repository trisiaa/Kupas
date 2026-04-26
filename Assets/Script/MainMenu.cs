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

    // 🔥 INI YANG PENTING
    public void PilihLevel(int level)
    {
        PlayerPrefs.SetInt("levelDipilih", level);
        SceneManager.LoadScene("ingame");
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}