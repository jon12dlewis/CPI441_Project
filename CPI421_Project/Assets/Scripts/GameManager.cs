using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public player player;
    public Transform player;
    public FloatingTextManager floatingTextManager;

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
        floatingTextManager = GameObject.Find("FloatingTextManager").GetComponent<FloatingTextManager>();
    }

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References


    //public Weapon weapon;

    

    // Logic
    public int mula;
    public int expierence;
    public int blue_crystals;
    public int yellow_crystals;
    public int red_crystals;

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
        floatingTextManager = GameObject.Find("FloatingTextManager").GetComponent<FloatingTextManager>();
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
        floatingTextManager = GameObject.Find("FloatingTextManager").GetComponent<FloatingTextManager>();
    }

    public void GiveBlueCrystal(int ammount)
    {
        Debug.Log("Blue Crystal Added");
        blue_crystals += ammount;
    }

    public void GiveRedCrystal(int ammount)
    {
        Debug.Log("Red Crystal Added");
        red_crystals += ammount;
    }

    public void GiveYellowCrystal(int ammount)
    {
        Debug.Log("Yellow Crystal Added");
        yellow_crystals += ammount;
    }

    public void GiveExpierence(int ammount)
    {
        Debug.Log("Expierence Added");
        expierence += ammount;
    }

    public void GiveMula(int ammount)
    {
        mula += ammount;
    }
}
