using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIHoverSnapshotToggle : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioMixerSnapshot snapshot1;
    [SerializeField] AudioMixerSnapshot snapshot2;
    [SerializeField] float transitionSpeed = 0.6f;
    [SerializeField] float transitionSpeed_2 = 0.6f;

    bool isOn;

    private AudioMixerSnapshot[] snapshots;
    private float[] weights = {1f, 0f};
    //private AudioEvents.MusicEvent stimulus;

    // on start of scene
    void Start() {
        snapshots = new AudioMixerSnapshot[2];
        snapshots[0] = snapshot1;
        snapshots[1] = snapshot2;
    }

    // toggles between the two provided snapshots
    public void ToggleSnapshot() {
        weights[0] = Mathf.Abs(weights[0] - 1);
        weights[1] = Mathf.Abs(weights[1] - 1);

        var speed = isOn ? transitionSpeed_2 : transitionSpeed;
        
        mixer.TransitionToSnapshots(snapshots, weights, speed);

        isOn = !isOn;
    }
}
