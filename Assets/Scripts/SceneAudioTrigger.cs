using System.Diagnostics;
using UnityEngine;

public class SceneAudioTrigger : MonoBehaviour
{
    // Berjalan satu kali saat scene ini baru dimulai
    void Start()
    {
        if (AudioManager.instance != null)
        {
            // Mengubah settingan audio mixer ke profil "Cutscene"
            UnityEngine.Debug.Log("Triggering Cutscene Audio Snapshot");
            AudioManager.instance.GoToCutscene();
        }
    }

    // Berjalan otomatis saat objek ini hancur 
    // (biasanya saat pindah ke scene lain)
    void OnDestroy()
    {
        if (AudioManager.instance != null)
        {
            // Mengembalikan settingan audio mixer ke profil "Normal"
            UnityEngine.Debug.Log("Returning to Normal Audio Snapshot");
            AudioManager.instance.GoToNormal();
        }
    }
}