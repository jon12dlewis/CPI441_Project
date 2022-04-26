using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool OtherUIOpen = false;
    public static PauseMenu Instance;
    bool inMenu;

    public GameObject pauseMenuUI;
    [SerializeField] AudioSource open;
    [SerializeField] AudioSource close;
    [SerializeField] AudioSource buttonClick;
    [SerializeField] AudioSource buttonHover;
    [SerializeField] Button homeButton;
    [SerializeField] Text homeButtonText;

    GameObject pauseMenu;
    GameObject soundMenu;
    GameObject controlsMenu;
    GameObject visualsMenu;

    void Awake() {
        SceneManager.activeSceneChanged += Reload;

        // the code in this method prevents this manager from being destroyed on scene transition and ensure only one exists at a time.
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (SceneManager.GetActiveScene().name == "HomeBase") DisableButton();

        pauseMenu = pauseMenuUI.transform.GetChild(0).gameObject;
        soundMenu = pauseMenuUI.transform.GetChild(1).gameObject;
        controlsMenu = pauseMenuUI.transform.GetChild(2).gameObject;
        visualsMenu = pauseMenuUI.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update ()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inMenu) return;

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
    void Resume ()
    {
        AudioEvents_V2.GameUnpaused();

        soundMenu.SetActive(false);
        controlsMenu.gameObject.SetActive(false);
        visualsMenu.gameObject.SetActive(false);

        pauseMenuUI.SetActive(false);

        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause ()
    {
        AudioEvents_V2.GamePaused();

        pauseMenuUI.SetActive(true);

        pauseMenu.SetActive(true);
        soundMenu.SetActive(false);
        controlsMenu.SetActive(false);
        visualsMenu.SetActive(false);

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
    void Reload(Scene current, Scene next) {
        GameIsPaused = false;
        OtherUIOpen = false;
        Resume();

        if (next.name == "HomeBase") {
            DisableButton();
        }
        else {
            EnableButton();
        }

        if (next.name == "Selection" && current.name != "Title") {
            inMenu = true;
        }
        else {
            inMenu = false;
        }
    }

    void DisableButton() {
        homeButtonText.color = new Color32(169, 99, 0, 217);
        homeButton.interactable = false;
    }
    
    void EnableButton() {
        homeButtonText.color = new Color32(255, 177, 13, 255);
        homeButton.interactable = true;
    }
}
