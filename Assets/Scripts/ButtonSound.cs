using UnityEngine;
using UnityEngine.UI;

// This line ensures a Button MUST exist on this object
[RequireComponent(typeof(Button))] 
public class ButtonSound : MonoBehaviour
{
    private Button myButton;

    void Start()
    {
        myButton = GetComponent<Button>();

        if (myButton != null)
        {
            myButton.onClick.AddListener(PlaySound);
        }
        else
        {
            Debug.LogError($"Button component missing on {gameObject.name}!");
        }
    }

    void PlaySound()
    {
        // Double check the AudioManager exists too!
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.buttons);
        }
    }
}