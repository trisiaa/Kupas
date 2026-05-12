using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [System.Serializable]
public class LevelItem
{
    public int progressIndex; // urutan unlock
    public int gameLevel;     // isi level di ingame

    public string sceneName;

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
            bool isUnlocked = lvl.progressIndex <= levelTerbuka;

            // tampilkan gembok
            if (lvl.lockImage != null)
                lvl.lockImage.SetActive(!isUnlocked);

            // aktif/nonaktif tombol
            if (lvl.button != null)
            {
                lvl.button.interactable = isUnlocked;

                int progress = lvl.progressIndex;
int gameLevel = lvl.gameLevel;
string scene = lvl.sceneName;

lvl.button.onClick.RemoveAllListeners();

if (isUnlocked)
{
    lvl.button.onClick.AddListener(() =>
        PilihLevel(progress, gameLevel, scene));
}
            }
        }
    }

    public void PilihLevel(int progressIndex, int gameLevel, string sceneName)
{
    int levelTerbuka = PlayerPrefs.GetInt("levelTerbuka", 1);

    if (progressIndex > levelTerbuka)
    {
        Debug.Log("Level masih terkunci!");
        return;
    }

    PlayButtonSound();

    PlayerPrefs.SetInt("levelDipilih", progressIndex);
    PlayerPrefs.SetInt("gameLevel", gameLevel);
    

    Debug.Log("Progress level: " + progressIndex);

    if (SceneTransitionManager.Instance != null)
    {
        SceneTransitionManager.Instance.NextLevel(sceneName);
    }
    else
    {
        SceneManager.LoadScene(sceneName);
    }
}

    public void ResetProgress()
    {
        PlayButtonSound();

        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("levelTerbuka", 1);

        Debug.Log("Progress di-reset!");

        string currentScene = SceneManager.GetActiveScene().name;

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