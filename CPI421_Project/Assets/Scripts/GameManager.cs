using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References

    public player player;

    //public Weapon weapon;

    public FloatingTextManager floatingTextManager;

    // Logic
    public int mula;
    public int expierence;

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);

    }

    // Save state
    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += mula.ToString() + "|";         // mula
        s += expierence.ToString() + "|";   // expierence
        s += "0";                           // weapon level 

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        
        // Change player skin

        mula = int.Parse(data[1]);
        expierence = int.Parse(data[2]);
        // change the weapon level

        Debug.Log("LoadState");
    }
}
