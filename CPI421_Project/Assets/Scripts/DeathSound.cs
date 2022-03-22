using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{

    void SetAudioSource(AudioSource inputSource) {
        AudioSource asource = gameObject.AddComponent<AudioSource>();
        asource.clip = inputSource.clip;
        asource.pitch = inputSource.pitch;
        asource.volume = inputSource.volume;
        asource.outputAudioMixerGroup = inputSource.outputAudioMixerGroup;
        asource.Play(0);
        Destroy(gameObject, asource.clip.length);
    }
}
