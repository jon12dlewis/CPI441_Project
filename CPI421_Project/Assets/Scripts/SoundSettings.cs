using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] Slider EnemySlider;

    // grab most recent saved values from PlayerPrefs
    void OnEnable() {
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1);
        MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);
        EnemySlider.value = PlayerPrefs.GetFloat("EnemyVolume", 1);
    }

    // set current values in PlayerPrefs
    void OnDisable() {
        PlayerPrefs.SetFloat("MasterVolume", MasterSlider.value);
        PlayerPrefs.SetFloat("MusicrVolume", MusicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
        PlayerPrefs.SetFloat("EnemyrVolume", EnemySlider.value);
    }
}
