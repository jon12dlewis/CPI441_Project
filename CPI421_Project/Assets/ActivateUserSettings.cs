using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUserSettings : MonoBehaviour
{
    SoundSettings sound;
    VisualSettings visual;
    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.AddComponent<SoundSettings>();
        visual = gameObject.AddComponent<VisualSettings>();
        sound.UpdateSettings();
        visual.UpdateSettings();
    }
}
