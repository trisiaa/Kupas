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

        PlayerPrefs.SetInt("levelDipilih", level);
        SceneManager.LoadScene("ingame");
    }

    public void ResetProgress()
{
    PlayerPrefs.DeleteAll(); 
    PlayerPrefs.SetInt("levelTerbuka", 1); // set ulang ke level 1

    Debug.Log("Progress di-reset!");

    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

}