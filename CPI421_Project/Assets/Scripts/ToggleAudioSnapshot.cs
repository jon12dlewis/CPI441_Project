using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ToggleAudioSnapshot : MonoBehaviour
{
    [SerializeField] GameObject StimulusKey;
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioMixerSnapshot snapshot1;
    [SerializeField] AudioMixerSnapshot snapshot2;
    [SerializeField] float transitionSpeed = 0.6f;

    private AudioMixerSnapshot[] snapshots;
    private float[] weights = {1f, 0f};
    //private AudioEvents.MusicEvent stimulus;

    // on start of scene
    void Start() {
        snapshots = new AudioMixerSnapshot[2];
        snapshots[0] = snapshot1;
        snapshots[1] = snapshot2;
    }

    // subscribe to events here
    void OnEnable()
    {
        Debug.Log(gameObject.name);
        ref var stimulus = ref AudioEvents.EventLookup(StimulusKey);
        stimulus += ToggleSnapshot;
    }

    // unsubscribe from events here
    void OnDisable()
    {
        ref var stimulus = ref AudioEvents.EventLookup(StimulusKey);
        stimulus -= ToggleSnapshot;
    }

    // toggles between the two provided snapshots
    void ToggleSnapshot() {
        weights[0] = Mathf.Abs(weights[0] - 1);
        weights[1] = Mathf.Abs(weights[1] - 1);
        
        mixer.TransitionToSnapshots(snapshots, weights, transitionSpeed);
        Debug.Log("Audio transition occurred");
    }
}
