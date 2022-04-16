using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text healthText, blueCrystalText, yellowCrystalText, redCrystalText, pickAxeDamage, weaponDamage, bowDamage;
    public player player; 
    public Sprite[] pickAxeImage, weaponImage, bowImage, helmetImage, chestImage, legsImage;
    public Image pickAxeDisplay, weaponDisplay, bowDisplay, helmetDisplay, chestDisplay, legsDisplay;
    public Image pickAxeUI, weaponUI, bowUI;

    public GameObject weapon;
    public GameObject pickAxe;
    public GameObject bow;

    int weaponSelected = 1;
    int pickAxeSelected = 1;
    int bowSelected = 1;
    int helmetSelected = 1;
    int chestSelected = 1;
    int legsSelected = 1;

    public int maxWeapon = 1;
    public int maxPickAxe = 1;
    public int maxBow = 1;
    public int maxHelmet = 1;
    public int maxChest = 1;
    public int maxLegs = 1;

    void Start()
    {
        displayWeapon();
        displayPickAxe();
        displayBow();
    }

    // Update is called once per frame
    public void UpdateMenu()
    {
        healthText.text = player.hitPoint.ToString() + "/" +player.maxHitpoint.ToString();
        blueCrystalText.text = GameManager.instance.blue_crystals.ToString();
        yellowCrystalText.text = GameManager.instance.yellow_crystals.ToString();
        redCrystalText.text = GameManager.instance.red_crystals.ToString();
    }

    public void setMax()
    {
        /*
        int[] weapons = GameManager.instance.weapons;
        int[] bows = GameManager.instance.bows;
        int[] pickAxes = GameManager.instance.pickaxes;
        int[] helmets = GameManager.instance.helmets;
        int[] chests = GameManager.instance.chests;
        int[] legs = GameManager.instance.legs;

        maxWeapon = 0;
        maxPickAxe = 0;
        maxBow = 0;
        maxHelmet = 0;
        maxChest = 0;
        maxLegs = 0;


        for(int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i] == 1)
            {
                maxWeapon += 1; 
            }

            if(pickAxes[i] == 1)
            {
                maxPickAxe += 1; 
            }

            if(bows[i] == 1)
            {
                maxBow += 1; 
            }

            if(helmets[i] == 1)
            {
                maxHelmet += 1; 
            }

            if(chests[i] == 1)
            {
                maxChest += 1; 
            }

            if(legs[i] == 1)
            {
                maxLegs += 1; 
            }
        }
        */
    }

    public void displayWeapon()
    {
        //setMax();
        weaponSelected = GameManager.instance.weaponLevel;
        weaponDisplay.sprite = weaponImage[weaponSelected-1];
        //GameManager.instance.setWeapon(weaponSelected);

        weapon.GetComponent<Weapon>().setImage(weaponImage[weaponSelected-1]);
        weaponUI.sprite = weaponImage[weaponSelected-1];



        switch(weaponSelected)
        {
            case 1:
                weaponDamage.text = "1";
                weapon.GetComponent<Weapon>().setDamage(1);
            break;
            case 2:
                weaponDamage.text = "3";
                weapon.GetComponent<Weapon>().setDamage(3);
            break;
            case 3:
                weaponDamage.text = "6";
                weapon.GetComponent<Weapon>().setDamage(6);
            break;

        }
    }


    public void displayBow()
    {
        //setMax();
        bowSelected = GameManager.instance.bowLevel;
        bowDisplay.sprite = bowImage[bowSelected-1];
        //GameManager.instance.setWeapon(weaponSelected);

        bow.GetComponent<Bow>().setImage(bowImage[bowSelected-1]);
        bowUI.sprite = bowImage[bowSelected-1];


        switch(bowSelected)
        {
            case 1:
                bowDamage.text = "1";
                //bow.GetComponent<Weapon>().setDamage(1);
                bowDamage.text = "1";
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
            break;
            case 2:
                bowDamage.text = "3";
                //bow.GetComponent<Weapon>().setDamage(3);
                bowDamage.text = "3";
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
            break;
            case 3:
                bowDamage.text = "6";
                bowDamage.text = "6";
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
                //bow.GetComponent<Bow>().setDamage(6);
            break;

        }

    }


    public void displayPickAxe()
    {
        //setMax();
        pickAxeSelected = GameManager.instance.pickaxeLevel;
        pickAxeDisplay.sprite = pickAxeImage[pickAxeSelected-1];
        //GameManager.instance.setWeapon(weaponSelected);

        pickAxe.GetComponent<PickAxe>().setImage(pickAxeImage[pickAxeSelected-1]);
        pickAxeUI.sprite = pickAxeImage[pickAxeSelected-1];


        switch(pickAxeSelected)
        {
            case 1:
                pickAxeDamage.text = "1";
                pickAxe.GetComponent<PickAxe>().setDamage(1);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);
            break;
            case 2:
                pickAxeDamage.text = "3";
                pickAxe.GetComponent<PickAxe>().setDamage(3);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);
            break;
            case 3:
                pickAxeDamage.text = "6";
                pickAxe.GetComponent<PickAxe>().setDamage(6);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);
            break;

        }
    }

    public void increaseBow()
    {
        setMax();
        bowSelected += 1;
        if(bowSelected > maxBow)
        {
            bowSelected = 1;
        }
        bowDisplay.sprite = bowImage[bowSelected-1];
        bowUI.sprite = bowImage[bowSelected-1];
        //GameManager.instance.setBow(bowSelected);
        bow.GetComponent<Bow>().setImage(bowImage[bowSelected-1]);
        
        switch(bowSelected)
        {
            case 1:
                bowDamage.text = "1";
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
            break;
            case 2:
                bowDamage.text = "2";
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
            break;
            case 3:
                bowDamage.text = "5";
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
            break;

        }
    }



    public void increasePickAxe()
    {
        setMax();
        pickAxeSelected += 1;
        if(pickAxeSelected > maxPickAxe)
        {
            pickAxeSelected = 1;
        }
        pickAxeDisplay.sprite = pickAxeImage[pickAxeSelected-1];
        pickAxeUI.sprite = pickAxeImage[pickAxeSelected-1];
        //GameManager.instance.setPickAxe(pickAxeSelected);
        pickAxe.GetComponent<PickAxe>().setImage(pickAxeImage[pickAxeSelected-1]);

        switch(pickAxeSelected)
        {
            case 1:
                pickAxeDamage.text = "1";
                pickAxe.GetComponent<PickAxe>().setDamage(1);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);
            break;
            case 2:
                pickAxeDamage.text = "2";
                pickAxe.GetComponent<PickAxe>().setDamage(2);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);

            break;
            case 3:
                pickAxeDamage.text = "5";
                pickAxe.GetComponent<PickAxe>().setDamage(5);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);
            break;

        }
    }


    public void increaseHelmet()
    {
        setMax();
        helmetSelected += 1;
        if(helmetSelected > maxHelmet)
        {
            helmetSelected = 1;
        }
        helmetDisplay.sprite = helmetImage[helmetSelected-1];
        GameManager.instance.setHelmet(helmetSelected);
        //helmet.setImage(helmetImage[pickAxeSelected-1]);

        switch(helmetSelected)
        {
            case 1:
            /*
                pickAxeDamage.text = "5";
                pickAxe.setDamage(5);
                pickAxe.setLevel(pickAxeSelected);
                */
            break;
            case 2:
            /*
                pickAxeDamage.text = "8";
                pickAxe.setDamage(8);
                pickAxe.setLevel(pickAxeSelected);
                */
            break;
            case 3:
            /*
                pickAxeDamage.text = "15";
                pickAxe.setDamage(15);
                pickAxe.setLevel(pickAxeSelected);
                */
            break;
            case 4:

            break;

        }
    }


    public void increaseChest()
    {
        setMax();
        chestSelected += 1;
        if(chestSelected > maxChest)
        {
            chestSelected = 1;
        }
        chestDisplay.sprite = chestImage[chestSelected-1];
        GameManager.instance.setChest(chestSelected);
        //chest.setImage(chestImage[chestSelected-1]);

        switch(chestSelected)
        {
            case 1:


            break;
            case 2:


            break;
            case 3:


            break;
            case 4:

            break;

        }
    }


    public void increaseLegs()
    {
        setMax();
        legsSelected += 1;
        if(legsSelected > maxLegs)
        {
            legsSelected = 1;
        }
        legsDisplay.sprite = legsImage[legsSelected-1];

        GameManager.instance.setLegs(legsSelected);
        //pickAxe.setImage(pickAxeImage[pickAxeSelected-1]);

        switch(legsSelected)
        {
            case 1:


            break;
            case 2:


            break;
            case 3:


            break;
            case 4:


            break;

        }
    }



}
