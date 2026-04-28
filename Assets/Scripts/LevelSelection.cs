using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void PilihLevel(int level)
    {
        PlayerPrefs.SetInt("levelDipilih", level);
        SceneManager.LoadScene("ingame");
    }
}