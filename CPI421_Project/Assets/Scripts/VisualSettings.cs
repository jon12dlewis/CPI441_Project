using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualSettings : MonoBehaviour
{
    [SerializeField] Toggle fullscreenToggle;

    // update UI elements to match PlayerPrefs
    void OnEnable() {
        fullscreenToggle.isOn = PlayerPrefs.GetInt("FullscreenOn", 1) == 1;
    }

    // log current settings to PlayerPrefs
    void OnDisable() {
        PlayerPrefs.SetInt("FullscreenOn", fullscreenToggle.isOn ? 1 : 0);
    }

    // Toggles FullScreen / Windowed mode
    public void ToggleFullscreen() {
        if (fullscreenToggle.isOn) {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}
