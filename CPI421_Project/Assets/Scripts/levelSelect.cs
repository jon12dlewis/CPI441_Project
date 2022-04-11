using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelect : MonoBehaviour
{
    public string[] sceneNames;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadLevel1()
    {
        GameManager.instance.SaveState();
        string sceneName = sceneNames[0];
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void loadLevel2()
    {
        GameManager.instance.SaveState();
        string sceneName = sceneNames[1];
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void loadLevel3()
    {
        GameManager.instance.SaveState();
        string sceneName = sceneNames[2];
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
