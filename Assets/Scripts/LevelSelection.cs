using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void PilihLevel(int level)
    {
        PlayButtonSound(); // <--- Play SFX
        PlayerPrefs.SetInt("levelDipilih", level);
        SceneManager.LoadScene("ingame");
    }

    private void PlayButtonSound()
    {
        if (AudioManager.instance != null)
        {
            // Mengambil AudioClip 'buttons' dari AudioManager
            AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
        }
    }
}