using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [Header("Scene Settings")]
    public string nextSceneName;

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

    // Pindah ke scene yang ditentukan di Inspector
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

    // Mengulang scene yang sedang aktif saat ini
    public void RestartScene()
    {
        // Mengambil nama scene yang sedang berjalan dan memuatnya ulang
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    // Keluar dari aplikasi
    public void QuitGame()
    {
        Debug.Log("Game is quitting..."); // Muncul di Console untuk testing
        
        #if UNITY_EDITOR
            // Jika sedang menjalankan di Unity Editor, hentikan Play Mode
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // Jika sudah menjadi aplikasi (Build), tutup aplikasinya
            Application.Quit();
        #endif
    }

    IEnumerator WaitAndChangeScene()
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadNextScene();
    }
}