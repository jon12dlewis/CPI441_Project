using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class setVolume : MonoBehaviour
{
    [SerializeField] public AudioMixer mixer;

    public void SetLevel(float sliderValue) {
        mixer.SetFloat("MixerVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicLevel(float sliderValue) {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSFXLevel(float sliderValue) {
        mixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetEnemyLevel(float sliderValue) {
        mixer.SetFloat("EnemyVol", Mathf.Log10(sliderValue) * 20);
    }
}
