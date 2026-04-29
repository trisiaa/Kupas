using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [Header("Scene Settings")]
    public string nextSceneName;
    public string mainMenuSceneName = "mainmenu";

    [Header("Timer Options")]
    public bool useTimer = false;
    public float delayInSeconds = 5f;

    [Header("Tutorial Settings")]
    public GameObject tutorialPanel;
    private bool isTutorialOpen = false;

    void Start()
    {
        Time.timeScale = 1f;

        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
        }

        if (useTimer)
        {
            StartCoroutine(WaitAndChangeScene());
        }
    }

    // Fungsi pembantu untuk memutar suara agar kode lebih bersih
    private void PlayButtonSound()
    {
        if (AudioManager.instance != null)
        {
            // Mengambil AudioClip 'buttons' dari AudioManager
            AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
        }
    }

    public void OpenTutorial()
    {
        PlayButtonSound(); // <--- Play SFX
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(true);
            Time.timeScale = 0f;
            isTutorialOpen = true;
        }
    }

    public void CloseTutorial()
    {
        PlayButtonSound(); // <--- Play SFX
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
            Time.timeScale = 1f;
            isTutorialOpen = false;
        }
    }

    // 1. Fungsi untuk memutar suara default 'buttons' yang ada di AudioManager
    public void PlayDefaultButtonSFX()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
        }
    }

    // 2. Fungsi yang lebih fleksibel: Kamu bisa memasukkan AudioClip apa saja langsung dari Inspector
    public void PlayCustomSFX(AudioClip clip)
    {
        if (AudioManager.instance != null && clip != null)
        {
            AudioManager.instance.PlaySFX(clip);
        }
    }

    public void RestartScene()
    {
        PlayButtonSound(); // <--- Play SFX
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
        PlayButtonSound(); // <--- Play SFX
        Time.timeScale = 1f;
        if (!string.IsNullOrEmpty(mainMenuSceneName))
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }

    public void QuitGame()
    {
        PlayButtonSound(); // <--- Play SFX
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void LoadNextScene()
    {
        PlayButtonSound(); // <--- Play SFX
        Time.timeScale = 1f;
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    IEnumerator WaitAndChangeScene()
    {
        yield return new WaitForSeconds(delayInSeconds);
        // LoadNextScene() sudah memanggil PlayButtonSound() di atas
        LoadNextScene();
    }
}