using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeHelper : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetMasterLevel(float sliderValue) {
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
