using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingStation : Collidable
{

    public GameObject craftingStation, helmetUpgradeButton, chestUpgradeButton, legUpgradeButton;

    public Text statsText, requirementsText;

    public Image chestImage, helmetImage, legImage;

    public Sprite[] chests, helmets, legs;

    [SerializeField] GameObject RisingTextContainer;
    RisingText errorMessage;
    [SerializeField] AudioSource errorSound;

    public int helmetLevel = 1;
    public int chestLevel = 1;
    public int legLevel = 1;

    public int max = 4;
    public int min = 0;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        statsText.text = "Stats:\nDefense: +1";
        requirementsText.text = "Requirements:\nYellow Crystals: 10 (" + GameManager.instance.GetYellowCrystal() + ")";
        helmetLevel = GameManager.instance.helmetLevel;

        errorMessage = RisingTextContainer.GetComponent<RisingText>();

        updateHelmetStats();
    }


    // displays the error message for not having enough crystals
    void NotEnoughCrystals() {
        Debug.Log("Not Enough Crystals");
        errorMessage.SetTravelingTrue();
        errorSound.Play();
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();  // Need to check collision

        helmetLevel = GameManager.instance.helmetLevel;
        if(helmetLevel != 0)
        {
            helmetImage.sprite = helmets[helmetLevel-1];
            helmetUpgradeButton.GetComponentInChildren<Text>().text = "Upgrade";
        }
        else
        {
            helmetImage.sprite = helmets[0];
            helmetUpgradeButton.GetComponentInChildren<Text>().text = "Craft";
        }
        
        if(helmetLevel >= 4)
        helmetUpgradeButton.SetActive(false);

        chestLevel = GameManager.instance.chestLevel;
        if(chestLevel != 0)
        {
            chestImage.sprite = chests[chestLevel-1];
            chestUpgradeButton.transform.GetChild(0).GetComponent<Text>().text = "Upgrade";
        }
        else
        {
            chestImage.sprite = chests[0];
            chestUpgradeButton.transform.GetChild(0).GetComponent<Text>().text = "Craft";
        }

        if(chestLevel >= 4)
        chestUpgradeButton.SetActive(false);

        legLevel = GameManager.instance.legLevel;
        if(legLevel != 0)
        {
            legImage.sprite = legs[legLevel-1];
            legUpgradeButton.transform.GetChild(0).GetComponent<Text>().text = "Upgrade";
        }
        else
        {
            legImage.sprite = legs[0];
            legUpgradeButton.transform.GetChild(0).GetComponent<Text>().text = "Craft";
        }


        if(legLevel >= 4)
        legUpgradeButton.SetActive(false);
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            craftingStation.SetActive(true);
        } 
    }
    /*
    public void nextArmor()
    {
        armor += min;
        Debug.Log("Switching to Helmet: " + armor);
        if(armor > max)
        {
            armor = min;
        }
    }
    */
    public void upgradeHelmet()
    {
        helmetLevel = GameManager.instance.helmetLevel;

        Debug.Log("upgrading helmet: " + helmetLevel);
        
        if(helmetLevel > max)
        {
            helmetLevel = max;
        }
        

        switch(helmetLevel)
        {
            case 0:
                 if(GameManager.instance.GetYellowCrystal() >= 10)
                {
                    helmetLevel = GameManager.instance.upgradeHelmetLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    helmetImage.sprite = helmets[helmetLevel];
                    Debug.Log("Crafting helmet 1");
                    updateHelmetStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 1:

                 if(GameManager.instance.GetYellowCrystal() >= 10 && GameManager.instance.GetBlueCrystal() >= 15)
                {
                    helmetLevel = GameManager.instance.upgradeHelmetLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    GameManager.instance.TakeBlueCrystal(15);
                    helmetImage.sprite = helmets[helmetLevel-1];
                    Debug.Log("Crafting helmet 2");
                    updateHelmetStats();
                }
                else
                {
                    NotEnoughCrystals();
                }

            break;

            case 2:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15)
                {
                    helmetLevel = GameManager.instance.upgradeHelmetLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    helmetImage.sprite = helmets[helmetLevel-1];
                    Debug.Log("Crafting helmet 3");
                    updateHelmetStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 3:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15 && GameManager.instance.GetBossCrystal() >= 1)
                {
                    helmetLevel = GameManager.instance.upgradeHelmetLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    GameManager.instance.TakeBossCrystal(1);
                    //if(helmetLevel >= 4)  
                    //    helmetLevel = 4;
                    helmetImage.sprite = helmets[helmetLevel-1];
                    Debug.Log("Crafting helmet 4");
                    helmetUpgradeButton.SetActive(false);
                    updateHelmetStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;


            default: 
                    
            break;
        }

       
    }


    public void upgradeChest()
    {
        chestLevel = GameManager.instance.chestLevel;

        Debug.Log("upgrading chest: " + chestLevel);
        
        if(chestLevel > max)
        {
            chestLevel = max;
        }
        

        switch(chestLevel)
        {
            case 0:
                 if(GameManager.instance.GetYellowCrystal() >= 10)
                {
                    chestLevel = GameManager.instance.upgradeChestLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    chestImage.sprite = chests[chestLevel];
                    Debug.Log("Crafting chest 1");
                    updateChestStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 1:

                 if(GameManager.instance.GetYellowCrystal() >= 10 && GameManager.instance.GetBlueCrystal() >= 15)
                {
                    chestLevel = GameManager.instance.upgradeChestLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    GameManager.instance.TakeBlueCrystal(15);
                    chestImage.sprite = chests[chestLevel-1];
                    Debug.Log("Crafting chest 2");
                    updateChestStats();
                }
                else
                {
                    NotEnoughCrystals();
                }

            break;

            case 2:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15)
                {
                    chestLevel = GameManager.instance.upgradeChestLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    chestImage.sprite = chests[chestLevel-1];
                    Debug.Log("Crafting chest 3");
                    updateChestStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 3:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15 && GameManager.instance.GetBossCrystal() >= 1)
                {
                    chestLevel = GameManager.instance.upgradeChestLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    GameManager.instance.TakeBossCrystal(1);
                    if(chestLevel >= 4)
                        chestLevel = 4;
                    chestImage.sprite = chests[chestLevel-1];
                    Debug.Log("Crafting chest 3");
                    chestUpgradeButton.SetActive(false);
                    updateChestStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;


            default: 
                    
            break;
        }

       
    }


    public void upgradeLegs()
    {
        legLevel = GameManager.instance.legLevel;

        Debug.Log("upgrading leg: " + legLevel);
        
        if(legLevel > max)
        {
            legLevel = max;
        }
        

        switch(legLevel)
        {
            case 0:
                 if(GameManager.instance.GetYellowCrystal() >= 10)
                {
                    legLevel = GameManager.instance.upgradeLegLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    legImage.sprite = legs[legLevel];
                    Debug.Log("Crafting leg 1");
                    updateLegStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 1:

                 if(GameManager.instance.GetYellowCrystal() >= 10 && GameManager.instance.GetBlueCrystal() >= 15)
                {
                    legLevel = GameManager.instance.upgradeLegLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    GameManager.instance.TakeBlueCrystal(15);
                    legImage.sprite = legs[legLevel-1];
                    Debug.Log("Crafting leg 2");
                    updateLegStats();
                }
                else
                {
                    NotEnoughCrystals();
                }

            break;

            case 2:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15)
                {
                    legLevel = GameManager.instance.upgradeLegLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    legImage.sprite = legs[legLevel-1];
                    Debug.Log("Crafting leg 3");
                    updateLegStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 3:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15 && GameManager.instance.GetBossCrystal() >= 1)
                {
                    legLevel = GameManager.instance.upgradeLegLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    GameManager.instance.TakeBossCrystal(1);
                    if(legLevel >= 4)
                        legLevel = 4;
                    legImage.sprite = legs[legLevel-1];
                    Debug.Log("Crafting leg 3");
                    legUpgradeButton.SetActive(false);
                    updateLegStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;


            default: 
                    
            break;
        }

       
    }


    public void updateHelmetStats()
    {
        switch(helmetLevel)
        {
            case 0:
                    statsText.text = "Stats:\nDiscovery: +1";
                    requirementsText.text = "Requirements:\nYellow Crystals: 10(" + GameManager.instance.GetYellowCrystal() + ")";
            break;
            case 1:
                    statsText.text = "Stats:\nDiscovery: +2";
                    requirementsText.text = "Requirements:\nYellow Crystals: 15(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 10(" + GameManager.instance.GetBlueCrystal() + ")";
            break;
            case 2:
                    statsText.text = "Stats:\nDiscovery: +3";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
            case 3:
                    statsText.text = "Stats:\nDiscovery: +4";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")\nQueen Crystals: 1(" + GameManager.instance.GetBossCrystal() +")" ;
            break;
        }
    }

    public void updateChestStats()
    {
        switch(chestLevel)
        {
            case 0:
                    statsText.text = "Stats:\nHealth: +2";
                    requirementsText.text = "Requirements:\nYellow Crystals: 10(" + GameManager.instance.GetYellowCrystal() + ")";
            break;
            case 1:
                    statsText.text = "Stats:\nHealth: +4";
                    requirementsText.text = "Requirements:\nYellow Crystals: 15(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 10(" + GameManager.instance.GetBlueCrystal() + ")";
            break;
            case 2:
                    statsText.text = "Stats:\nHealth: +7";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
            case 3:
                    statsText.text = "Stats:\nBuff: Regen";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")\nQueen Crystals: 1(" + GameManager.instance.GetBossCrystal() +")" ;
            break;
        }
    }

    public void updateLegStats()
    {
        switch(legLevel)
        {
            case 0:
                    statsText.text = "Stats:\nSpeed: +10%";
                    requirementsText.text = "Requirements:\nYellow Crystals: 10(" + GameManager.instance.GetYellowCrystal() + ")";
            break;
            case 1:
                    statsText.text = "Stats:\nSpeed: +20%";
                    requirementsText.text = "Requirements:\nYellow Crystals: 15(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 10(" + GameManager.instance.GetBlueCrystal() + ")";
            break;
            case 2:
                    statsText.text = "Stats:\nSpeed: +30%";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
            case 3:
                    statsText.text = "Stats:\nSpeed: +50%";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")\nQueen Crystals: 1(" + GameManager.instance.GetBossCrystal() +")" ;
            break;
        }
    }

    


/*
    public void craftHelmet1()
    {
        if(GameManager.instance.GetYellowCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(10);
            GameManager.instance.helmets[0] = 1;
            Debug.Log("Crafting Helmet 1");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftHelmet2()
    {
        if(GameManager.instance.GetYellowCrystal() >= 15 && GameManager.instance.GetBlueCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(50);
            GameManager.instance.TakeBlueCrystal(10);
            GameManager.instance.helmets[1] = 1;
            Debug.Log("Crafting Helmet 2");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftHelmet3()
    {
        if(GameManager.instance.GetYellowCrystal() >= 30 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 5)
        {
            GameManager.instance.TakeYellowCrystal(30);
            GameManager.instance.TakeBlueCrystal(20);
            GameManager.instance.TakeRedCrystal(5);
            GameManager.instance.helmets[2] = 1;
            Debug.Log("Crafting Helmet 3");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }



    public void craftChest1()
    {
        if(GameManager.instance.GetYellowCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(10);
            GameManager.instance.chests[0] = 1;

            Debug.Log("Crafting Chest 1");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftChest2()
    {
        if(GameManager.instance.GetYellowCrystal() >= 15 && GameManager.instance.GetBlueCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(15);
            GameManager.instance.TakeBlueCrystal(10);
            GameManager.instance.chests[1] = 1;
            Debug.Log("Crafting Chest 2");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftChest3()
    {
        if(GameManager.instance.GetYellowCrystal() >= 30 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 5)
        {
            GameManager.instance.TakeYellowCrystal(30);
            GameManager.instance.TakeBlueCrystal(20);
            GameManager.instance.TakeRedCrystal(5);
            GameManager.instance.chests[2] = 1;

            Debug.Log("Crafting Chest 3");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftBoots1()
    {
        if(GameManager.instance.GetYellowCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(10);
            GameManager.instance.legs[0] = 1;
            Debug.Log("Crafting Boots 1");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftBoots2()
    {
        if(GameManager.instance.GetYellowCrystal() >= 15 && GameManager.instance.GetBlueCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(15);
            GameManager.instance.TakeBlueCrystal(10);
            GameManager.instance.legs[1] = 1;

            Debug.Log("Crafting Boots 2");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftBoots3()
    {
        if(GameManager.instance.GetYellowCrystal() >= 30 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 5)
        {
            GameManager.instance.TakeYellowCrystal(30);
            GameManager.instance.TakeBlueCrystal(20);
            GameManager.instance.TakeRedCrystal(5);
            GameManager.instance.legs[2] = 1;

            Debug.Log("Crafting Boots 3");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void updateStats()
    {
        switch(armor)
        {
            case 1:
                    statsText.text = "Stats:\nDefense: +3";
            break;
            case 2:
                    statsText.text = "Stats:\nDefense: +10";
            break;
            case 3:
                    statsText.text = "Stats:\nDefense: +15";
            break;
        }
    }

    public void updateRequirements()
    {
        switch(armor)
        {
            case 1:
                    requirementsText.text = "Requirements:\nYellow Crystals: 10(" + GameManager.instance.GetYellowCrystal() + ")";
            break;

            case 2:
                    requirementsText.text = "Requirements:\nYellow Crystals: 15(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 10(" + GameManager.instance.GetBlueCrystal() + ")";
            break;

            case 3:
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
        }
    }

    public void resetArmor()
    {
        armor = 1;
    }

    */

}
