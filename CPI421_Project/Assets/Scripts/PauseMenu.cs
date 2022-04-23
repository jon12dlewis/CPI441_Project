using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool OtherUIOpen = false;

    public GameObject pauseMenuUI;
    [SerializeField] AudioSource open;
    [SerializeField] AudioSource close;
    [SerializeField] AudioSource buttonClick;
    [SerializeField] AudioSource buttonHover;

    void Awake() {
        SceneManager.sceneLoaded += Reload;
    }

    // Update is called once per frame
    void Update ()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                close.Play(0);
                if (!OtherUIOpen) Resume();
            }
            else
            {
                if (!OtherUIOpen) {
                    open.Play(0);
                    Pause();
                }
                else {
                    close.Play();
                }
            }
        }
    }
    public void Resume ()
    {
        
        AudioEvents_V2.GamePaused();
        pauseMenuUI.transform.GetChild(0).gameObject.SetActive(false);
        pauseMenuUI.transform.GetChild(1).gameObject.SetActive(false);
        pauseMenuUI.transform.GetChild(2).gameObject.SetActive(false);

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause ()
    {
        AudioEvents_V2.GamePaused();
        pauseMenuUI.SetActive(true);
        pauseMenuUI.transform.GetChild(0).gameObject.SetActive(true);
        pauseMenuUI.transform.GetChild(1).gameObject.SetActive(false);
        pauseMenuUI.transform.GetChild(2).gameObject.SetActive(false);
        pauseMenuUI.transform.GetChild(3).gameObject.SetActive(false);

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

    // necessary to reset these when we change scenes because animators don't close
    void Reload(Scene scene, LoadSceneMode mode) {
        GameIsPaused = false;
        OtherUIOpen = false;
    }
}
