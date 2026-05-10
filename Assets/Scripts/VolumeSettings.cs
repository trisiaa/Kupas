using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        // 1. Load the values from global memory (PlayerPrefs)
        // If the key doesn't exist yet, we default to 0.75f (75% volume)
        float savedMusic = PlayerPrefs.GetFloat("musicVolume", 0.75f);
        float savedSFX = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        // 2. Force the Sliders to show the saved values
        if (musicSlider != null) musicSlider.value = savedMusic;
        if (SFXSlider != null) SFXSlider.value = savedSFX;

        // 3. Immediately apply these to the AudioMixer
        ApplyMusicVolume(savedMusic);
        ApplySFXVolume(savedSFX);
    }

    // Called by the Music Slider's OnValueChanged event
    public void OnMusicSliderChanged()
    {
        float volume = musicSlider.value;
        ApplyMusicVolume(volume);
        PlayerPrefs.SetFloat("musicVolume", volume); // Save globally
    }

    // Called by the SFX Slider's OnValueChanged event
    public void OnSFXSliderChanged()
    {
        float volume = SFXSlider.value;
        ApplySFXVolume(volume);
        PlayerPrefs.SetFloat("SFXVolume", volume); // Save globally
    }

    private void ApplyMusicVolume(float value)
    {
        // Math to convert 0-1 slider to decibels
        float dB = Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20;
        myMixer.SetFloat("music", dB);
    }

    private void ApplySFXVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20;
        myMixer.SetFloat("SFX", dB);
    }
}