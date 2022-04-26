using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStation : Collidable
{

    public GameObject weaponStation, weaponUpgradeButton, pickAxeUpgradeButton, bowUpgradeButton;

    public Text statsText, requirementsText;

    public Image bowImage, weaponImage, pickAxeImage;

    public Sprite[] bows, weapons, pickAxes;

    public int weaponLevel = 1;
    public int pickAxeLevel = 1;
    public int bowLevel = 1;

    public int max = 3;
    public int min = 1;

    [SerializeField] GameObject RisingTextContainer;
    RisingText errorMessage;
    [SerializeField] AudioSource errorSound;

    // Start is called before the first frame update
protected override void Start()
    {
        base.Start();
        statsText.text = "Stats:\nAttack: +1";
        requirementsText.text = "Requirements:\nYellow Crystals: 10 (" + GameManager.instance.GetYellowCrystal() + ")";
        weaponLevel = GameManager.instance.weaponLevel;
        updateWeaponStats();

        errorMessage = RisingTextContainer.GetComponent<RisingText>();
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
         weaponLevel = GameManager.instance.weaponLevel;
         //weaponImage.sprite = weapons[weaponLevel];
        if(weaponLevel != 0)
        {
            weaponImage.sprite = weapons[weaponLevel-1];
            weaponUpgradeButton.GetComponentInChildren<Text>().text = "Upgrade";
        }
        else
        {
            weaponImage.sprite = weapons[0];
            weaponUpgradeButton.GetComponentInChildren<Text>().text = "Craft";
        }
         if(weaponLevel >= 4)
            weaponUpgradeButton.SetActive(false);


        pickAxeLevel = GameManager.instance.pickaxeLevel;
        //pickAxeImage.sprite = pickAxes[pickAxeLevel];

        if(pickAxeLevel != 0)
        {
            pickAxeImage.sprite = pickAxes[pickAxeLevel-1];
            pickAxeUpgradeButton.GetComponentInChildren<Text>().text = "Upgrade";
        }
        else
        {
            pickAxeImage.sprite = pickAxes[0];
            pickAxeUpgradeButton.GetComponentInChildren<Text>().text = "Craft";
        }
        if(pickAxeLevel >= 4)
            pickAxeUpgradeButton.SetActive(false);

        bowLevel = GameManager.instance.bowLevel;

        //bowImage.sprite = bows[bowLevel];

        if(bowLevel != 0)
        {
            bowImage.sprite = bows[bowLevel-1];
            bowUpgradeButton.GetComponentInChildren<Text>().text = "Upgrade";
        }
        else
        {
            bowImage.sprite = bows[0];
            bowUpgradeButton.GetComponentInChildren<Text>().text = "Craft";
        }


        if(bowLevel >= 4)
            bowUpgradeButton.SetActive(false);

        
    }

    protected override void OnCollide(Collider2D coll)
    {

        if(coll.name == "Player")
        {
            Debug.Log("Start menu");
            weaponStation.SetActive(true);

        }
        else
        {
            weaponStation.SetActive(false);
        }

    }


    public void upgradeWeapon()
    {
        weaponLevel = GameManager.instance.weaponLevel;

        Debug.Log("upgrading weapon: " + weaponLevel);
        
        if(weaponLevel > max)
        {
            weaponLevel = min;
        }
        

        switch(weaponLevel)
        {

            case 0:
                 if(GameManager.instance.GetYellowCrystal() >= 10)
                {
                    weaponLevel = GameManager.instance.upgradeWeaponLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    weaponImage.sprite = weapons[weaponLevel];
                    Debug.Log("Crafting Sword 1");
                    updateWeaponStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 1:

                 if(GameManager.instance.GetYellowCrystal() >= 10 && GameManager.instance.GetBlueCrystal() >= 15)
                {
                    weaponLevel = GameManager.instance.upgradeWeaponLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    GameManager.instance.TakeBlueCrystal(15);
                    weaponImage.sprite = weapons[weaponLevel-1];
                    Debug.Log("Crafting Sword 2");
                    updateWeaponStats();
                }
                else
                {
                    NotEnoughCrystals();
                }

            break;

            case 2:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15)
                {
                    weaponLevel = GameManager.instance.upgradeWeaponLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    weaponImage.sprite = weapons[weaponLevel-1];
                    Debug.Log("Crafting Sword 3");
                    updateWeaponStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 3:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15  && GameManager.instance.GetBossCrystal() >= 1)
                {
                    weaponLevel = GameManager.instance.upgradeWeaponLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    GameManager.instance.TakeBossCrystal(1);
                    weaponImage.sprite = weapons[weaponLevel-1];
                    Debug.Log("Crafting Sword 3");
                    weaponUpgradeButton.SetActive(false);
                    updateWeaponStats();
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



    public void upgradePickAxe()
    {

        Debug.Log("upgrading weapon: " + pickAxeLevel);
        

        switch(pickAxeLevel)
        {
            case 0:
                 if(GameManager.instance.GetYellowCrystal() >= 10)
                {
                    pickAxeLevel = GameManager.instance.upgradePickAxeLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    pickAxeImage.sprite = pickAxes[pickAxeLevel];
                    Debug.Log("Crafting PickAxe 1");
                    updatePickAxeStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 1:

                 if(GameManager.instance.GetYellowCrystal() >= 10 && GameManager.instance.GetBlueCrystal() >= 15)
                {
                    pickAxeLevel = GameManager.instance.upgradePickAxeLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    GameManager.instance.TakeBlueCrystal(15);
                    pickAxeImage.sprite = pickAxes[pickAxeLevel-1];
                    Debug.Log("Crafting pickAxe 2");
                    updatePickAxeStats();
                }
                else
                {
                    NotEnoughCrystals();
                }

            break;

            case 2:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15)
                {
                    pickAxeLevel = GameManager.instance.upgradePickAxeLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    pickAxeImage.sprite = pickAxes[pickAxeLevel-1];
                    Debug.Log("Crafting Sword 3");
                    updatePickAxeStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 3:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15  && GameManager.instance.GetBossCrystal() >= 1)
                {
                    pickAxeLevel = GameManager.instance.upgradePickAxeLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    GameManager.instance.TakeBossCrystal(1);
                    pickAxeImage.sprite = pickAxes[pickAxeLevel-1];
                    Debug.Log("Crafting Sword 3");
                    pickAxeUpgradeButton.SetActive(false);
                    updatePickAxeStats();
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



    public void upgradeBow()
    {
         Debug.Log("upgrading bow: " + pickAxeLevel);
        

        switch(bowLevel)
        {
            case 0:
                 if(GameManager.instance.GetYellowCrystal() >= 10)
                {
                    bowLevel = GameManager.instance.upgradeBowLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    bowImage.sprite = bows[bowLevel];
                    Debug.Log("Crafting Bow 1");
                    updateBowStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;

            case 1:

                 if(GameManager.instance.GetYellowCrystal() >= 10 && GameManager.instance.GetBlueCrystal() >= 15)
                {
                    bowLevel = GameManager.instance.upgradeBowLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    GameManager.instance.TakeBlueCrystal(15);
                    bowImage.sprite = bows[bowLevel-1];
                    Debug.Log("Crafting Bow 2");
                    updateBowStats();
                }
                else
                {
                    NotEnoughCrystals();
                }

            break;

            case 2:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15)
                {
                    bowLevel = GameManager.instance.upgradeBowLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    bowImage.sprite = bows[bowLevel-1];
                    Debug.Log("Crafting Bow 3");
                    updateBowStats();
                }
                else
                {
                    NotEnoughCrystals();
                }
            break;
            case 3:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15  && GameManager.instance.GetBossCrystal() >= 1)
                {
                    bowLevel = GameManager.instance.upgradeBowLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    GameManager.instance.TakeBossCrystal(1);
                    bowImage.sprite = bows[bowLevel-1];
                    Debug.Log("Crafting Bow 3");
                    bowUpgradeButton.SetActive(false);
                    updateBowStats();
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

    public void updatePickAxeStats()
    {
        switch(pickAxeLevel)
        {
            case 0:
                    statsText.text = "Stats:\nDamage: +1";
                    requirementsText.text = "Requirements:\nYellow Crystals: 10(" + GameManager.instance.GetYellowCrystal() + ")";
            break;
            case 1:
                    statsText.text = "Stats:\nDamage: +3";
                    requirementsText.text = "Requirements:\nYellow Crystals: 15(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 10(" + GameManager.instance.GetBlueCrystal() + ")";
            break;
            case 2:
                    statsText.text = "Stats:\nDamage: +5";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
            case 3:
                    statsText.text = "Stats:\nDamage: +8";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")\nQueen Crystals: 1(" + GameManager.instance.GetBossCrystal() +")" ;
            break;
        }
    }

    public void updateBowStats()
    {
        switch(bowLevel)
        {
            case 0:
                    statsText.text = "Stats:\nDamage: +1";
                    requirementsText.text = "Requirements:\nYellow Crystals: 10(" + GameManager.instance.GetYellowCrystal() + ")";
            break;
            case 1:
                    statsText.text = "Stats:\nDamage: +3";
                    requirementsText.text = "Requirements:\nYellow Crystals: 15(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 10(" + GameManager.instance.GetBlueCrystal() + ")";
            break;
            case 2:
                    statsText.text = "Stats:\nDamage: +5";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
            case 3:
                    statsText.text = "Stats:\nDamage: +8";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")\nQueen Crystals: 1(" + GameManager.instance.GetBossCrystal() +")" ;
            break;
        }
    }


    public void updateWeaponStats()
    {
        switch(weaponLevel)
        {
            case 0:
                    statsText.text = "Stats:\nDamage: +1";
                    requirementsText.text = "Requirements:\nYellow Crystals: 10(" + GameManager.instance.GetYellowCrystal() + ")";
            break;
            case 1:
                    statsText.text = "Stats:\nDamage: +3";
                    requirementsText.text = "Requirements:\nYellow Crystals: 15(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 10(" + GameManager.instance.GetBlueCrystal() + ")";
            break;
            case 2:
                    statsText.text = "Stats:\nDamage: +5";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
            case 3:
                    statsText.text = "Stats:\nDamage: +8";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")\nQueen Crystals: 1(" + GameManager.instance.GetBossCrystal() +")" ;
            break;
        }
    }


}
