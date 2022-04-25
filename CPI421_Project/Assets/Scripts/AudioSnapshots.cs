using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSnapshots : MonoBehaviour
{
    [SerializeField] GameObject OnKey;
    [SerializeField] GameObject OffKey;
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
        ref var stimulus = ref AudioEvents_V2.EventLookup(OnKey);
        ref var stimulus2 = ref AudioEvents_V2.EventLookup(OffKey);
        stimulus += SnapshotOn;
        stimulus2 += SnapshotOff;
    }

    // unsubscribe from events here
    void OnDisable()
    {
        ref var stimulus = ref AudioEvents_V2.EventLookup(OnKey);
        ref var stimulus2 = ref AudioEvents_V2.EventLookup(OffKey);
        stimulus -= SnapshotOn;
        stimulus2 -= SnapshotOff;
    }

    void SnapshotOn() {
        weights[0] = 0;
        weights[1] = 1;
        
        mixer.TransitionToSnapshots(snapshots, weights, transitionSpeed);
        Debug.Log("Audio transition occurred");
    }

    void SnapshotOff() {
        weights[0] = 1;
        weights[1] = 0;
        
        mixer.TransitionToSnapshots(snapshots, weights, transitionSpeed);
        Debug.Log("Audio transition occurred");
    }
}
