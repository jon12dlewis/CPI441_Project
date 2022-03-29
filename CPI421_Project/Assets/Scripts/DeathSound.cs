using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    AudioSource asource;

    // called via SendMessage() in OnDestroy() functions
    void SetAudioSource(AudioSource inputSource) {

        // create new audio source
        asource = gameObject.AddComponent<AudioSource>();

        // copy attributes of input audio source to new audio source
        asource.clip = inputSource.clip;
        asource.pitch = inputSource.pitch;
        asource.volume = inputSource.volume;
        asource.outputAudioMixerGroup = inputSource.outputAudioMixerGroup;

        // play new audio source
        asource.Play(0);

        // destroy self after audio source is played
        Destroy(gameObject, asource.clip.length);
    }
}
