using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    
    [SerializeField] AudioMixer[] mixers;
    [SerializeField] AudioMixerSnapshot[][] snapshots;
    [SerializeField] float[][] weights;

    enum Mixer {Bass, Chords, Lead};

    // intializing jagged arrays in the start function
    void Start() {
        weights = new float[mixers.Length][];
        snapshots = new AudioMixerSnapshot[mixers.Length][];

        for (int i = 0; i < mixers.Length; i++) {
            weights[i] = new float[] {1f, 0f};
            snapshots[i] = new AudioMixerSnapshot[] {mixers[i].FindSnapshot("Off"), mixers[i].FindSnapshot("On")};
        }
    }

    // subscribe to the events
    void OnEnable() {
        GreenTrigger.ToggleGreen += ToggleChords;
        BlueTrigger.ToggleBlue += ToggleBass;
        RedTrigger.ToggleRed += ToggleLead;
    }

    // unsubscribe to the events
    void OnDisable() {
        GreenTrigger.ToggleGreen -= ToggleChords;
        BlueTrigger.ToggleBlue -= ToggleBass;
        RedTrigger.ToggleRed -= ToggleLead;
    }

    // toggles the bass track
    void ToggleBass() {
        int bass = (int)Mixer.Bass;

        if (weights[bass][0] == 1) {
            weights[bass][0] = 0;
            weights[bass][1] = 1;
        }
        else {
            weights[bass][0] = 1;
            weights[bass][1] = 0;
        }

        mixers[bass].TransitionToSnapshots(snapshots[bass], weights[bass], 0.3f);
    }

    // toggles the chords track
    void ToggleChords() {
        int chords = (int)Mixer.Chords;

        if (weights[chords][0] == 1) {
            weights[chords][0] = 0;
            weights[chords][1] = 1;
        }
        else {
            weights[chords][0] = 1;
            weights[chords][1] = 0;
        }

        mixers[chords].TransitionToSnapshots(snapshots[chords], weights[chords], 0.3f);
    }

    // toggles the lead track
    void ToggleLead() {
        int lead = (int)Mixer.Lead;

        if (weights[lead][0] == 1) {
            weights[lead][0] = 0;
            weights[lead][1] = 1;
        }
        else {
            weights[lead][0] = 1;
            weights[lead][1] = 0;
        }

        mixers[lead].TransitionToSnapshots(snapshots[lead], weights[lead], 0.3f);
    }
}
