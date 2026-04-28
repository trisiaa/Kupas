using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [Header("Scene Settings")]
    public string nextSceneName;
    public string mainMenuSceneName = "mainmenu"; // Nama scene menu utama Anda

    [Header("Timer Options")]
    public bool useTimer = false;
    public float delayInSeconds = 5f;

    void Start()
    {
        if (useTimer)
        {
            StartCoroutine(WaitAndChangeScene());
        }
    }

    // Pindah ke scene yang ditentukan di Inspector (misal: Level Berikutnya)
    public void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Nama scene berikutnya belum diisi!");
        }
    }

    // KHUSUS: Kembali ke Main Menu
    public void BackToMainMenu()
    {
        if (!string.IsNullOrEmpty(mainMenuSceneName))
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
        else
        {
            Debug.LogError("Nama scene Main Menu belum ditentukan di Inspector!");
        }
    }

    // Mengulang scene yang sedang aktif saat ini
    public void RestartScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    // Keluar dari aplikasi
    public void QuitGame()
    {
        Debug.Log("Game is quitting..."); 
        
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