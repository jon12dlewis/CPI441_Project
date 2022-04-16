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

    // Start is called before the first frame update
protected override void Start()
    {
        base.Start();
        statsText.text = "Stats:\nAttack: +1";
        requirementsText.text = "Requirements:\nYellow Crystals: 10 (" + GameManager.instance.GetYellowCrystal() + ")";
        weaponLevel = GameManager.instance.weaponLevel;
        updateWeaponStats();
    }

    // Update is called once per frame
    protected override void Update()
    {
         base.Update();  // Need to check collision
         weaponLevel = GameManager.instance.weaponLevel;
         weaponImage.sprite = weapons[weaponLevel - 1];
         if(weaponLevel >= 4)
            weaponUpgradeButton.SetActive(false);

        pickAxeLevel = GameManager.instance.pickaxeLevel;
        pickAxeImage.sprite = pickAxes[pickAxeLevel - 1];
        if(pickAxeLevel >= 4)
            pickAxeUpgradeButton.SetActive(false);


        
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
            case 1:
                 if(GameManager.instance.GetYellowCrystal() >= 10)
                {
                    weaponLevel = GameManager.instance.upgradeWeaponLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    weaponImage.sprite = weapons[weaponLevel - 1];
                    Debug.Log("Crafting Sword 1");
                    updateWeaponStats();
                }
                else
                {
                    Debug.Log("Not Enough Crystals");
                }
            break;

            case 2:

                 if(GameManager.instance.GetYellowCrystal() >= 10 && GameManager.instance.GetBlueCrystal() >= 15)
                {
                    weaponLevel = GameManager.instance.upgradeWeaponLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    GameManager.instance.TakeBlueCrystal(15);
                    weaponImage.sprite = weapons[weaponLevel - 1];
                    Debug.Log("Crafting Sword 2");
                    updateWeaponStats();
                }
                else
                {
                    Debug.Log("Not Enough Crystals");
                }

            break;

            case 3:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15)
                {
                    weaponLevel = GameManager.instance.upgradeWeaponLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    if(weaponLevel >= 4)
                        weaponLevel = 3;
                    weaponImage.sprite = weapons[weaponLevel - 1];
                    Debug.Log("Crafting Sword 3");
                    weaponUpgradeButton.SetActive(false);
                    updateWeaponStats();
                }
                else
                {
                    Debug.Log("Not Enough Crystals");
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
            case 1:
                 if(GameManager.instance.GetYellowCrystal() >= 10)
                {
                    pickAxeLevel = GameManager.instance.upgradePickAxeLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    pickAxeImage.sprite = pickAxes[pickAxeLevel - 1];
                    Debug.Log("Crafting PickAxe 1");
                    updatePickAxeStats();
                }
                else
                {
                    Debug.Log("Not Enough Crystals");
                }
            break;

            case 2:

                 if(GameManager.instance.GetYellowCrystal() >= 10 && GameManager.instance.GetBlueCrystal() >= 15)
                {
                    pickAxeLevel = GameManager.instance.upgradePickAxeLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    GameManager.instance.TakeBlueCrystal(15);
                    pickAxeImage.sprite = pickAxes[pickAxeLevel - 1];
                    Debug.Log("Crafting pickAxe 2");
                    updatePickAxeStats();
                }
                else
                {
                    Debug.Log("Not Enough Crystals");
                }

            break;

            case 3:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15)
                {
                    pickAxeLevel = GameManager.instance.upgradePickAxeLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    if(pickAxeLevel >= 4)
                        pickAxeLevel = 3;
                    pickAxeImage.sprite = pickAxes[pickAxeLevel - 1];
                    Debug.Log("Crafting Sword 3");
                    pickAxeUpgradeButton.SetActive(false);
                    updatePickAxeStats();
                }
                else
                {
                    Debug.Log("Not Enough Crystals");
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
            case 1:
                 if(GameManager.instance.GetYellowCrystal() >= 10)
                {
                    bowLevel = GameManager.instance.upgradeBowLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    bowImage.sprite = bows[bowLevel - 1];
                    Debug.Log("Crafting Bow 1");
                    updateBowStats();
                }
                else
                {
                    Debug.Log("Not Enough Crystals");
                }
            break;

            case 2:

                 if(GameManager.instance.GetYellowCrystal() >= 10 && GameManager.instance.GetBlueCrystal() >= 15)
                {
                    bowLevel = GameManager.instance.upgradeBowLevel();
                    GameManager.instance.TakeYellowCrystal(10);
                    GameManager.instance.TakeBlueCrystal(15);
                    bowImage.sprite = bows[bowLevel - 1];
                    Debug.Log("Crafting Bow 2");
                    updateBowStats();
                }
                else
                {
                    Debug.Log("Not Enough Crystals");
                }

            break;

            case 3:
                if(GameManager.instance.GetYellowCrystal() >= 20 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 15)
                {
                    bowLevel = GameManager.instance.upgradeBowLevel();
                    GameManager.instance.TakeYellowCrystal(20);
                    GameManager.instance.TakeBlueCrystal(20);
                    GameManager.instance.TakeRedCrystal(15);
                    if(bowLevel >= 4)
                        bowLevel = 3;
                    bowImage.sprite = bows[bowLevel - 1];
                    Debug.Log("Crafting Bow 3");
                    bowUpgradeButton.SetActive(false);
                    updateBowStats();
                }
                else
                {
                    Debug.Log("Not Enough Crystals");
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
            case 1:
                    statsText.text = "Stats:\nDamage: +1";
                    requirementsText.text = "Requirements:\nYellow Crystals: 10(" + GameManager.instance.GetYellowCrystal() + ")";
            break;
            case 2:
                    statsText.text = "Stats:\nDamage: +3";
                    requirementsText.text = "Requirements:\nYellow Crystals: 15(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 10(" + GameManager.instance.GetBlueCrystal() + ")";
            break;
            case 3:
                    statsText.text = "Stats:\nDamage: +5";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
            case 4:
                    statsText.text = "Stats:\nDamage: +8";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
        }
    }

    public void updateBowStats()
    {
        switch(bowLevel)
        {
            case 1:
                    statsText.text = "Stats:\nDamage: +1";
                    requirementsText.text = "Requirements:\nYellow Crystals: 10(" + GameManager.instance.GetYellowCrystal() + ")";
            break;
            case 2:
                    statsText.text = "Stats:\nDamage: +3";
                    requirementsText.text = "Requirements:\nYellow Crystals: 15(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 10(" + GameManager.instance.GetBlueCrystal() + ")";
            break;
            case 3:
                    statsText.text = "Stats:\nDamage: +5";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
            case 4:
                    statsText.text = "Stats:\nDamage: +8";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
        }
    }


    public void updateWeaponStats()
    {
        switch(weaponLevel)
        {
            case 1:
                    statsText.text = "Stats:\nDamage: +1";
                    requirementsText.text = "Requirements:\nYellow Crystals: 10(" + GameManager.instance.GetYellowCrystal() + ")";
            break;
            case 2:
                    statsText.text = "Stats:\nDamage: +3";
                    requirementsText.text = "Requirements:\nYellow Crystals: 15(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 10(" + GameManager.instance.GetBlueCrystal() + ")";
            break;
            case 3:
                    statsText.text = "Stats:\nDamage: +5";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
            case 4:
                    statsText.text = "Stats:\nDamage: +8";
                    requirementsText.text = "Requirements:\nYellow Crystals: 30(" + GameManager.instance.GetYellowCrystal() + ")\nBlue Crystals: 20(" + GameManager.instance.GetBlueCrystal() + ")\nRed Crystals: 5(" + GameManager.instance.GetRedCrystal() +")" ;
            break;
        }
    }


}
