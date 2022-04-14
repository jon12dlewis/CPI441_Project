using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ActivateUserSettings : MonoBehaviour
{
    SoundSettings sound;
    VisualSettings visual;
    [SerializeField] AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.AddComponent<SoundSettings>();
        visual = gameObject.AddComponent<VisualSettings>();
        sound.SetMixer(mixer);
        sound.UpdateSettings();
        visual.UpdateSettings();
    }
}
