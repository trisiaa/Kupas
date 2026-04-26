using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public float delayInSeconds = 5f;
    public string nextSceneName;

    void Start()
    {
        StartCoroutine(WaitAndChangeScene());
    }

    IEnumerator WaitAndChangeScene()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(nextSceneName);
    }
}