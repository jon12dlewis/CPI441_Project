using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public player player;
    public Transform player;
    public Transform playerStartPos;
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
        player = GameObject.Find("Player").GetComponent<Transform>();   // TODO: player does not exist in home base scene
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
    public int blue_crystals = 0;
    public int yellow_crystals = 0;
    public int red_crystals = 0;
    public int bossCrystals = 0;
    
    public int helmetLevel = 1;
    public int chestLevel = 1;
    public int legLevel = 1;
    public int weaponLevel = 1;
    public int pickaxeLevel = 1;
    public int bowLevel = 1;
    public int arrows = 0;
    public int levelsCompleted = 1;
    public int pickAxeSelected = 1;
    public int weaponSelected = 1;
    public int bowSelected = 1;
    public int helmetSelected = 1;
    public int chestSelected = 1;
    public int legSelected = 1;


    

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

        s += "0" + 1;
        s += blue_crystals.ToString() + "|";                        // Blue Crystals
        s += yellow_crystals.ToString() + "|";                      // Red Crystals
        s += red_crystals.ToString() + "|";                         // Yellow Crystals
        s += weaponLevel.ToString() + "|";                           // weapon level
        s += bowLevel.ToString() + "|";                              // bow level
        s += pickaxeLevel.ToString() + "|";                          // pickaxe level 
        s += helmetLevel.ToString() + "|";                           // helmet level 1 unlocked 1 = yes 0 = no
        s += chestLevel.ToString() + "|";                            // chest level 1 unlocked 1 = yes 0 = no
        s += legLevel.ToString() + "|";                              // legs level 1 unlocked 1 = yes 0 = no
        s += arrows.ToString() + "|";
        s += levelsCompleted.ToString() + "|";                      // Level one completed
        s += pickAxeSelected.ToString() + "|";                      
        s += weaponSelected.ToString() + "|";                       
        s += bowSelected.ToString() + "|";
        s += helmetSelected.ToString() + "|";
        s += chestSelected.ToString() + "|";
        s += legSelected.ToString()  + "|";
        s += bossCrystals.ToString();
        
        //"0|0|0|0|1|1|1|1|1|1|0|1|1|1|1|1|1"

        PlayerPrefs.SetString("SaveState", s);
        floatingTextManager = GameObject.Find("FloatingTextManager").GetComponent<FloatingTextManager>();
        //player = GameObject.Find("Player").GetComponent<Transform>();
    }

    public void newGame()
    {
        string s = "0|0|0|0|0|0|1|0|0|0|0|1|1|1|1|1|1|0";
        PlayerPrefs.SetString("SaveState", s);
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
        weaponLevel = int.Parse(data[4]);
        bowLevel = int.Parse(data[5]);
        pickaxeLevel = int.Parse(data[6]);
        helmetLevel = int.Parse(data[7]);
        chestLevel = int.Parse(data[8]);
        legLevel = int.Parse(data[9]);
        arrows = int.Parse(data[10]);
        levelsCompleted = int.Parse(data[11]);
        pickAxeSelected = int.Parse(data[12]);
        weaponSelected = int.Parse(data[13]);
        bowSelected = int.Parse(data[14]);
        helmetSelected = int.Parse(data[15]);
        chestSelected = int.Parse(data[16]);
        legSelected = int.Parse(data[17]);
        bossCrystals = int.Parse(data[18]);

        // change the weapon level

        Debug.Log("LoadState");
        floatingTextManager = GameObject.Find("FloatingTextManager").GetComponent<FloatingTextManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        playerStartPos = GameObject.Find("PlayerStartingPosition").GetComponent<Transform>();
        if(player != null && playerStartPos != null)
            player.position = playerStartPos.position;
    }

    public string getString()
    {
        string s = "";

        s += "0" + "|";                                             // buffer doesnt do anything
        s += blue_crystals.ToString() + "|";                        // Blue Crystals
        s += yellow_crystals.ToString() + "|";                      // Red Crystals
        s += red_crystals.ToString() + "|";                         // Yellow Crystals
        s += weaponLevel.ToString() + "|";                           // weapon level
        s += bowLevel.ToString() + "|";                              // bow level
        s += pickaxeLevel.ToString() + "|";                          // pickaxe level 
        s += helmetLevel.ToString() + "|";                           // helmet level 1 unlocked 1 = yes 0 = no
        s += chestLevel.ToString() + "|";                            // chest level 1 unlocked 1 = yes 0 = no
        s += legLevel.ToString() + "|";                              // legs level 1 unlocked 1 = yes 0 = no
        s += arrows.ToString() + "|";                                // number of arrows the player has
        s += levelsCompleted.ToString() + "|";                      // Level one completed
        s += pickAxeSelected.ToString() + "|";                      
        s += weaponSelected.ToString() + "|";                       
        s += bowSelected.ToString() + "|";
        s += helmetSelected.ToString() + "|";
        s += chestSelected.ToString() + "|";
        s += legSelected.ToString() + "|";
        s += bossCrystals.ToString();

        return s;

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

    public void GiveBossCrystal(int ammount)
    {
        Debug.Log("Boss Crystal Added");
        bossCrystals += ammount;
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

    public void TakeBossCrystal(int ammount)
    {
        Debug.Log("Boss Crystal Taken");
        bossCrystals -= ammount;
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

    public int GetBossCrystal()
    {
        return bossCrystals;
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

    public int upgradeWeaponLevel()
    {
        weaponLevel += 1;
        return weaponLevel;
    }

    public int upgradePickAxeLevel()
    {
        pickaxeLevel += 1;
        return pickaxeLevel;
    }

    public int upgradeBowLevel()
    {
        bowLevel += 1;
        return bowLevel;
    }

    public int upgradeHelmetLevel()
    {
        helmetLevel += 1;
        return helmetLevel;
    }

    public int upgradeChestLevel()
    {
        chestLevel += 1;
        return chestLevel;
    }

    public int upgradeLegLevel()
    {
        legLevel += 1;
        return legLevel;
    }

    public void nextLevel()
    {
        levelsCompleted += 1;
    }

}
