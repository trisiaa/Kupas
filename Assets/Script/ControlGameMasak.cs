using UnityEngine;

public class ControlGameMasak : MonoBehaviour
{
    public void ButtonAnimation(Animator animatorButton)
    {
        animatorButton.Play("ButtonPressed", 0, 0f);
    }
}