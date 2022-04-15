using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public delegate void SceneChangeEvent(); 
    public static SceneChangeEvent gameStart;

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // emits a game start event so that we can switch the music
        // if (gameStart != null) {
        //     gameStart();
        // }

    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
