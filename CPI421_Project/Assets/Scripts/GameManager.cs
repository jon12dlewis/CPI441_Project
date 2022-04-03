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
    
    public int[] helmets = [0,0,0];
    public int[] chests = [0,0,0];
    public int[] legs = [0,0,0];
    public int[] weapons = [0,0,0];
    public int[] pickaxes = [0,0,0];
    public int[] bows = [0,0,0];
    public int arrows = 0;
    public int levelsCompleted;
    

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Save state
    public void SaveState()
    {
        string s = "";

        //s += "0" + "|";
        s += blue_crystals.ToString() + "|";         // Blue Crystals
        s += yellow_crystals.ToString() + "|";   // Red Crystals
        s += red_crystals.ToString() + "|";   // Yellow Crystals
        s += weapons[0] + "|";                           // weapon level 1 unlocked 1 = yes 0 = no
        s += weapons[1] + "|";                           // weapon level 2 unlocked 1 = yes 0 = no
        s += weapons[2] + "|";                           // weapon level 3 unlocked 1 = yes 0 = no
        s += bows[0] + "|";                           // bow level 1 unlocked 1 = yes 0 = no
        s += bows[1] + "|";                           // bow level 2 unlocked 1 = yes 0 = no
        s += bows[2] + "|";                           // bow level 3 unlocked 1 = yes 0 = no
        s += pickaxes[0] + "|";                           // pickaxe level 1 unlocked 1 = yes 0 = no
        s += pickaxes[1] + "|";                           // piackaxe level 2 unlocked 1 = yes 0 = no
        s += pickaxes[2] + "|";                           // pickaxe level 3 unlocked 1 = yes 0 = no
        s += helmets[0] + "|";                           // helmet level 1 unlocked 1 = yes 0 = no
        s += helmets[1] + "|";                           // helmet level 2 unlocked 1 = yes 0 = no
        s += helmets[2] + "|";                           // helmet level 3 unlocked 1 = yes 0 = no
        s += chests[0] + "|";                           // chest level 1 unlocked 1 = yes 0 = no
        s += chests[1] + "|";                           // chest level 2 unlocked 1 = yes 0 = no
        s += chests[2] + "|";                           // chest level 3 unlocked 1 = yes 0 = no
        s += legs[0] + "|";                           // legs level 1 unlocked 1 = yes 0 = no
        s += legs[1] + "|";                           // legs level 2 unlocked 1 = yes 0 = no
        s += legs[2] + "|";                           // legs level 3 unlocked 1 = yes 0 = no
        s += arrows + "|";
        s += levelsCompleted;                           // Level one completed

        PlayerPrefs.SetString("SaveState", s);
        floatingTextManager = GameObject.Find("FloatingTextManager").GetComponent<FloatingTextManager>();
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if(!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        
        // Change player skin

        blue_crystals = int.Parse(data[1]);
        yellow_crystals = int.Parse(data[2]);
        red_crystals = int.Parse(data[3]);
        weapons[0] = int.Parse(data[4]);;
        weapons[1] = int.Parse(data[5]);;
        weapons[2] = int.Parse(data[6]);;
        bows[0] = int.Parse(data[7]);
        bows[0] = int.Parse(data[8]);
        bows[0] = int.Parse(data[9]);
        pickaxes[0] = int.Parse(data[10]);
        pickaxes[0] = int.Parse(data[11]);
        pickaxes[0] = int.Parse(data[12]);
        helmets[0] = int.Parse(data[13]);
        helmets[0] = int.Parse(data[14]);
        helmets[0] = int.Parse(data[15]);
        chests[0] = int.Parse(data[16]);
        chests[0] = int.Parse(data[17]);
        chests[0] = int.Parse(data[18]);
        legs[0] = int.Parse(data[19]);
        legs[0] = int.Parse(data[20]);
        legs[0] = int.Parse(data[21]);
        arrows = int.Parse(data[22]);
        levelsCompleted = int.Parse(data[23]); 
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

    public void TakeBlueCrystal(int ammount)
    {
        Debug.Log("Blue Crystal Taken");
        blue_crystals -= ammount;
    }

    public void TakeRedCrystal(int ammount)
    {
        Debug.Log("Red Crystal Taken");
        red_crystals -= ammount;
    }

    public void TakeYellowCrystal(int ammount)
    {
        Debug.Log("Yellow Crystal Taken");
        yellow_crystals -= ammount;
    }



    public int GetBlueCrystal()
    {
        return blue_crystals;
    }

    public int GetRedCrystal()
    {
        return red_crystals;
    }

    public int GetYellowCrystal()
    {
        return yellow_crystals;
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
