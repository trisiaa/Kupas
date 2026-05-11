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

    [Header("Skip Settings")]
    public bool canSkip = true;
    public GameObject skipButton;
    public float skipButtonDelay = 2f; 

    [Header("Level Info")]
    public int levelIndex = 0;

    [Header("Tutorial Settings")]
    public GameObject tutorialPanel;
    private bool isTutorialOpen = false;

    private Coroutine timerCoroutine;

    void Awake()
    {

        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
        }

        if (skipButton != null)
        {
            skipButton.SetActive(false);
            if (canSkip)
            {
                StartCoroutine(ShowSkipButtonAfterDelay());
            }
        }

        if (useTimer)
        {
            timerCoroutine = StartCoroutine(WaitAndChangeScene());
        }
    }

    IEnumerator ShowSkipButtonAfterDelay()
    {
        yield return new WaitForSeconds(skipButtonDelay);
        if (skipButton != null)
        {
            skipButton.SetActive(true);
        }
    }

    public void SkipScene()
    {
        if (canSkip)
        {
            if (timerCoroutine != null)
            {
                StopCoroutine(timerCoroutine);
            }
            LoadNextScene();
        }
    }

    private void PlayButtonSound()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
        }
    }

    public void OpenTutorial()
    {
        PlayButtonSound();
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(true);
            Time.timeScale = 0f;
            isTutorialOpen = true;
        }
    }

    public void CloseTutorial()
    {
        PlayButtonSound();
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
            Time.timeScale = 1f;
            isTutorialOpen = false;
        }
    }

    // --- UPDATED NAVIGATION METHODS TO USE TRANSITION INSTANCE ---

    public void RestartScene()
    {
        PlayButtonSound();
        Time.timeScale = 1f;
        string currentScene = SceneManager.GetActiveScene().name;

        // Check if the Transition Manager exists, otherwise load normally
        if (SceneTransitionManager.Instance != null)
            SceneTransitionManager.Instance.NextLevel(currentScene);
        else
            SceneManager.LoadScene(currentScene);
    }

    public void BackToMainMenu()
    {
        PlayButtonSound();
        Time.timeScale = 1f;
        if (!string.IsNullOrEmpty(mainMenuSceneName))
        {
            if (SceneTransitionManager.Instance != null)
                SceneTransitionManager.Instance.NextLevel(mainMenuSceneName);
            else
                SceneManager.LoadScene(mainMenuSceneName);
        }
    }

    public void LoadNextScene()
{
    PlayButtonSound();
    Time.timeScale = 1f;

    // simpan level yang dimainkan
    if (levelIndex > 0)
    {
        PlayerPrefs.SetInt("levelDipilih", levelIndex);

        Debug.Log("Set levelDipilih: " + levelIndex);
    }

    if (!string.IsNullOrEmpty(nextSceneName))
    {
        if (SceneTransitionManager.Instance != null)
            SceneTransitionManager.Instance.NextLevel(nextSceneName);
        else
            SceneManager.LoadScene(nextSceneName);
    }
}
    public void QuitGame()
    {
        PlayButtonSound();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    IEnumerator WaitAndChangeScene()
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadNextScene();
    }
}