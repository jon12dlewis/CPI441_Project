using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider EnemySlider;
    AudioMixer mixer;

    // grab most recent saved values from PlayerPrefs
    void OnEnable() {
        if (MasterSlider != null) {
            MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1);
            MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
            EnemySlider.value = PlayerPrefs.GetFloat("EnemyVolume", 1);
        }
    }

    // set current values in PlayerPrefs
    void OnDisable() {
        if (MasterSlider != null) {
            PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
            PlayerPrefs.SetFloat("MusicVolume", MusicSlider.value);
            PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
            PlayerPrefs.SetFloat("EnemyVolume", EnemySlider.value);
        }
    }

    // called by GameManager to update settings on launch
    public void UpdateSettings() {
        Debug.Log(mixer);

        setVolume("MixerVol", PlayerPrefs.GetFloat("MasterVolume", 1), mixer);
        setVolume("MusicVol", PlayerPrefs.GetFloat("MusicVolume", 1), mixer);
        setVolume("SFXVol", PlayerPrefs.GetFloat("SFXVolume", 1), mixer);
        setVolume("EnemyVol", PlayerPrefs.GetFloat("EnemyVolume", 1), mixer);
    }

    // helper method
    void setVolume(string sliderName, float sliderValue, AudioMixer mixer) {
        mixer.SetFloat(sliderName, Mathf.Log10(sliderValue) * 20);
    }

    public void SetMixer(AudioMixer mixerIn) {
        mixer = mixerIn;
    }
}
