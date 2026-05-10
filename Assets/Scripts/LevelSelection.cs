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

        // 1. Play sound and save choice
        PlayButtonSound();
        PlayerPrefs.SetInt("levelDipilih", level);

        // 2. Decide which scene to load
        string targetScene = (level == 1) ? "CutsceneIntro" : "ingame";

        // 3. Call the Transition Manager via Instance
        if (SceneTransitionManager.Instance != null)
        {
            SceneTransitionManager.Instance.NextLevel(targetScene);
        }
        else
        {
            // Fallback if manager is missing
            SceneManager.LoadScene(targetScene);
        }
    }

    public void ResetProgress()
    {
        PlayButtonSound();
        PlayerPrefs.DeleteAll(); 
        PlayerPrefs.SetInt("levelTerbuka", 1); 
        
        Debug.Log("Progress di-reset!");

        string currentScene = SceneManager.GetActiveScene().name;

        // Call the Transition Manager via Instance
        if (SceneTransitionManager.Instance != null)
        {
            SceneTransitionManager.Instance.NextLevel(currentScene);
        }
        else
        {
            SceneManager.LoadScene(currentScene);
        }
    }

    private void PlayButtonSound()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
        }
    }
}