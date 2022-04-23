using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// this class allows the music from the title scene to continue playing in the main menu and home base
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource music;

    private void Awake()
    {
        // the code in this method prevents this manager from being destroyed on scene transition and ensure only one exists at a time.
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable() {
        levelSelect.loadLevel += StopMenuMusic;
        levelSelect.loadHomeBase += PlayMenuMusic;
    }

    void OnDisable() {
        levelSelect.loadLevel -= StopMenuMusic;
        levelSelect.loadHomeBase -= PlayMenuMusic;
    }

    void PlayMenuMusic() {
        if (!music.isPlaying) {
            music.Play();
        }
    }

    void StopMenuMusic() {
        if (music.isPlaying) {
            music.Stop();
        }
    }
}
