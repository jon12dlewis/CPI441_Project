using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    [SerializeField] GameObject pauseEventKey;    // for use with toggling audio state
    [SerializeField] AudioSource open;
    [SerializeField] AudioSource close;
    [SerializeField] AudioSource buttonClick;
    [SerializeField] AudioSource buttonHover;

    // Update is called once per frame
    void Update ()
    { if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioEvents.TriggerEvent(pauseEventKey);    // changes to pause music

            if (GameIsPaused)
            {
                close.Play(0);
                Resume();
            }
            else
            {
                open.Play(0);
                Pause();
            }
        }
    }
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Selection");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    public void ButtonSound() {
        buttonClick.Play(0);
    }
    public void ButtonHover() {
        buttonHover.Play(0);
    }
}
