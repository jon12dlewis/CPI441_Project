using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelect : MonoBehaviour
{
    public string[] sceneNames;
    public delegate void MusicEvent();
    public static MusicEvent loadHomeBase;
    public static MusicEvent loadLevel;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    public void onOpen()
    {
        switch(GameManager.instance.levelsCompleted)
        {
            case 1:
                animator.SetTrigger("level1");
            break;
            case 2:
                animator.SetTrigger("level2");
            break;
            case 3:
                animator.SetTrigger("level3");
            break;
            default:
                animator.SetTrigger("level1");
            break;
        }
    }

    public void loadLevel1()
    {
        GameManager.instance.SaveState();
        string sceneName = sceneNames[0];
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        if (loadLevel != null) loadLevel();
    }

    public void loadLevel2()
    {
        GameManager.instance.SaveState();
        string sceneName = sceneNames[1];
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        if (loadLevel != null) loadLevel();
    }

    public void loadLevel3()
    {
        GameManager.instance.SaveState();
        string sceneName = sceneNames[2];
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        if (loadLevel != null) loadLevel();
    }

    public void loadLevelHomeBase()
    {
        GameManager.instance.SaveState();
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomeBase");
        if (loadHomeBase != null) loadHomeBase();
    }

    public void loadLevelMainMenu()
    {
        GameManager.instance.SaveState();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Selection");
        // if (loadHomeBase != null) loadHomeBase();
    }
}
