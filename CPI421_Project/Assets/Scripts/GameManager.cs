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
    
    public int[] helmets = {1,0,0};
    public int[] chests = {1,0,0};
    public int[] legs = {1,0,0};
    public int[] weapons = {1,0,0};
    public int[] pickaxes = {1,0,0};
    public int[] bows = {1,0,0};
    public int arrows = 0;
    public int levelsCompleted;
    public int pickAxeSelected;
    public int weaponSelected;
    public int bowSelected;
    public int helmetSelected;
    public int chestSelected;
    public int legSelected;
    

    // Floating text
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Save state
    public void SaveState()
    {
        Debug.Log("Save State");
        string s = "";

        s += "0" + "|";
        s += blue_crystals.ToString() + "|";                        // Blue Crystals
        s += yellow_crystals.ToString() + "|";                      // Red Crystals
        s += red_crystals.ToString() + "|";                         // Yellow Crystals
        s += weapons[0].ToString() + "|";                           // weapon level 1 unlocked 1 = yes 0 = no
        s += weapons[1].ToString() + "|";                           // weapon level 2 unlocked 1 = yes 0 = no
        s += weapons[2].ToString() + "|";                           // weapon level 3 unlocked 1 = yes 0 = no
        s += bows[0].ToString() + "|";                              // bow level 1 unlocked 1 = yes 0 = no
        s += bows[1].ToString() + "|";                              // bow level 2 unlocked 1 = yes 0 = no
        s += bows[2].ToString() + "|";                              // bow level 3 unlocked 1 = yes 0 = no
        s += pickaxes[0].ToString() + "|";                          // pickaxe level 1 unlocked 1 = yes 0 = no
        s += pickaxes[1].ToString() + "|";                          // piackaxe level 2 unlocked 1 = yes 0 = no
        s += pickaxes[2].ToString() + "|";                          // pickaxe level 3 unlocked 1 = yes 0 = no
        s += helmets[0].ToString() + "|";                           // helmet level 1 unlocked 1 = yes 0 = no
        s += helmets[1].ToString() + "|";                           // helmet level 2 unlocked 1 = yes 0 = no
        s += helmets[2].ToString() + "|";                           // helmet level 3 unlocked 1 = yes 0 = no
        s += chests[0].ToString() + "|";                            // chest level 1 unlocked 1 = yes 0 = no
        s += chests[1].ToString() + "|";                            // chest level 2 unlocked 1 = yes 0 = no
        s += chests[2].ToString() + "|";                            // chest level 3 unlocked 1 = yes 0 = no
        s += legs[0].ToString() + "|";                              // legs level 1 unlocked 1 = yes 0 = no
        s += legs[1].ToString() + "|";                              // legs level 2 unlocked 1 = yes 0 = no
        s += legs[2].ToString() + "|";                              // legs level 3 unlocked 1 = yes 0 = no
        s += arrows.ToString() + "|";
        s += levelsCompleted.ToString() + "|";                      // Level one completed
        s += pickAxeSelected.ToString() + "|";                      
        s += weaponSelected.ToString() + "|";                       
        s += bowSelected.ToString() + "|";
        s += helmetSelected.ToString() + "|";
        s += chestSelected.ToString() + "|";
        s += legSelected.ToString();

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
        weapons[0] = int.Parse(data[4]);
        weapons[1] = int.Parse(data[5]);
        weapons[2] = int.Parse(data[6]);
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
        pickAxeSelected = int.Parse(data[24]);
        weaponSelected = int.Parse(data[25]);
        bowSelected = int.Parse(data[26]);
        helmetSelected = int.Parse(data[27]);
        chestSelected = int.Parse(data[28]);
        legSelected = int.Parse(data[29]);

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

    public void setWeapon(int selection)
    {
        weaponSelected = selection;
    }

    public void setPickAxe(int selection)
    {
        pickAxeSelected = selection;
    }

    public void setBow(int selection)
    {
        bowSelected = selection;
    }

    public void setHelmet(int selection)
    {
        helmetSelected = selection;
    }

    public void setChest(int selection)
    {
        chestSelected = selection;
    }

    public void setLegs(int selection)
    {
        legSelected = selection;
    }

}
