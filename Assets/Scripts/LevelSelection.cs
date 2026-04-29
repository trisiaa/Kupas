using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [System.Serializable]
    public class LevelItem
    {
        public int levelIndex;        
        public GameObject lockImage;  
        public Button button;         
    }

    public LevelItem[] levels;

    void Start()
    {

        if (!PlayerPrefs.HasKey("levelTerbuka"))
        {
            PlayerPrefs.SetInt("levelTerbuka", 1);
        }

        int levelTerbuka = PlayerPrefs.GetInt("levelTerbuka", 1);

        foreach (LevelItem lvl in levels)
        {
            bool isUnlocked = lvl.levelIndex <= levelTerbuka;

         
            if (lvl.lockImage != null)
                lvl.lockImage.SetActive(!isUnlocked);

        
            if (lvl.button != null)
                lvl.button.interactable = isUnlocked;
        }
    }

    public void PilihLevel(int level)
    {
    int levelTerbuka = PlayerPrefs.GetInt("levelTerbuka", 1);

    if (level > levelTerbuka)
    {
        Debug.Log("Level masih terkunci!");
        return;
    }

    // Simpan level yang dipilih agar scene 'ingame' tahu harus load data apa
    PlayerPrefs.SetInt("levelDipilih", level);

    // LOGIKA BARU: Cek apakah level ini butuh scene pembuka?
    if (level == 1) // Contoh: Level 5 punya cerita pembuka
    {
        SceneManager.LoadScene("CutsceneIntro");
    }
    else
    {
        // Level normal langsung ke gameplay
        SceneManager.LoadScene("ingame");
    }
    }

    public void ResetProgress()
{
    PlayerPrefs.DeleteAll(); // hapus semua progress
    PlayerPrefs.SetInt("levelTerbuka", 1); // set ulang ke level 1

    Debug.Log("Progress di-reset!");

    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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