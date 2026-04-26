using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject goodBoyImage;
    public float cutsceneTime = 5f;
    public string sceneToLoad; 

    private bool hasTriggered = false;

    // --- ADD THIS METHOD BELOW ---
    // This is what the Player script is looking for!
    public void ActivateTrigger()
    {
        gameObject.SetActive(true);
    }
    // -----------------------------

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            StartCoroutine(PlayCutscene());
        }
    }

    IEnumerator PlayCutscene()
    {
        goodBoyImage.SetActive(true);
        yield return new WaitForSeconds(cutsceneTime);
        SceneManager.LoadScene(sceneToLoad);
    }
}