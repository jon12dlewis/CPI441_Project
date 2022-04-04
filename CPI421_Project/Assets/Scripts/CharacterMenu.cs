using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text healthText, blueCrystalText, yellowCrystalText, redCrystalText, pickAxeDamage, weaponDamage, bowDamage;
    public player player; 
    public Sprite[] pickAxeImage, weaponImage, bowImage;
    public Image pickAxeDisplay, weaponDisplay, bowDisplay;
    public Weapon weapon;
    public PickAxe pickAxe;
    public Bow bow;

    int weaponSelected = 1;
    int pickAxeSelected = 1;
    int bowSelected = 1;

    // Update is called once per frame
    public void UpdateMenu()
    {
        healthText.text = player.hitPoint.ToString() + "/" +player.maxHitpoint.ToString();
        blueCrystalText.text = GameManager.instance.blue_crystals.ToString();
        yellowCrystalText.text = GameManager.instance.yellow_crystals.ToString();
        redCrystalText.text = GameManager.instance.red_crystals.ToString();
    }

    public void increaseWeapon()
    {
        weaponSelected += 1;
        if(weaponSelected > 3)
        {
            weaponSelected = 1;
        }
        weaponDisplay.sprite = weaponImage[weaponSelected-1];
        GameManager.instance.setWeapon(weaponSelected);

        weapon.setImage(weaponImage[weaponSelected-1]);

        switch(weaponSelected)
        {
            case 1:
                weaponDamage.text = "5";
                weapon.setDamage(5);
            break;
            case 2:
                weaponDamage.text = "8";
                weapon.setDamage(8);
            break;
            case 3:
                weaponDamage.text = "15";
                weapon.setDamage(15);
            break;

        }
    }

    public void decreaseWeapon()
    {
        weaponSelected -= 1;
        if(weaponSelected < 1)
        {
            weaponSelected = 3;
        }
        weaponDisplay.sprite = weaponImage[weaponSelected-1];
        GameManager.instance.setWeapon(weaponSelected);
        weapon.setDamage(1);
        weapon.setImage(weaponImage[weaponSelected-1]);

        switch(weaponSelected)
        {
            case 1:
                weaponDamage.text = "5";
                weapon.setDamage(5);
            break;
            case 2:
                weaponDamage.text = "8";
                weapon.setDamage(8);
            break;
            case 3:
                weaponDamage.text = "15";
                weapon.setDamage(15);
            break;

        }

    }

    public void increaseBow()
    {
        bowSelected += 1;
        if(bowSelected > 3)
        {
            bowSelected = 1;
        }
        bowDisplay.sprite = bowImage[bowSelected-1];
        GameManager.instance.setBow(bowSelected);
        bow.setImage(bowImage[bowSelected-1]);
        
        switch(bowSelected)
        {
            case 1:
                bowDamage.text = "5";
                //bow.setDamage(5);
            break;
            case 2:
                bowDamage.text = "8";
                //bow.setDamage(8);
            break;
            case 3:
                bowDamage.text = "15";
                //bow.setDamage(15);
            break;

        }
    }

    public void decreaseBow()
    {
        bowSelected -= 1;
        if(bowSelected < 1)
        {
            bowSelected = 3;
        }
        bowDisplay.sprite = bowImage[bowSelected-1];
        GameManager.instance.setBow(bowSelected);
        bow.setImage(bowImage[bowSelected-1]);

        switch(bowSelected)
        {
            case 1:
                bowDamage.text = "5";
                //bow.setDamage(5);
            break;
            case 2:
                bowDamage.text = "8";
                //bow.setDamage(8);
            break;
            case 3:
                bowDamage.text = "15";
                //bow.setDamage(15);
            break;

        }
    }


    public void increasePickAxe()
    {
        pickAxeSelected += 1;
        if(pickAxeSelected > 3)
        {
            pickAxeSelected = 1;
        }
        pickAxeDisplay.sprite = pickAxeImage[pickAxeSelected-1];
        GameManager.instance.setPickAxe(pickAxeSelected);
        pickAxe.setImage(pickAxeImage[pickAxeSelected-1]);

        switch(pickAxeSelected)
        {
            case 1:
                pickAxeDamage.text = "5";
                pickAxe.setDamage(5);
            break;
            case 2:
                pickAxeDamage.text = "8";
                pickAxe.setDamage(8);
            break;
            case 3:
                pickAxeDamage.text = "15";
                pickAxe.setDamage(15);
            break;

        }
    }

    public void decreasePickAxe()
    {
        pickAxeSelected -= 1;
        if(pickAxeSelected < 1)
        {
            pickAxeSelected = 3;
        }
        pickAxeDisplay.sprite = pickAxeImage[pickAxeSelected-1];
        GameManager.instance.setPickAxe(pickAxeSelected);
        pickAxe.setImage(pickAxeImage[pickAxeSelected-1]);

        switch(pickAxeSelected)
        {
            case 1:
                pickAxeDamage.text = "5";
                pickAxe.setDamage(5);
            break;
            case 2:
                pickAxeDamage.text = "8";
                pickAxe.setDamage(8);
            break;
            case 3:
                pickAxeDamage.text = "15";
                pickAxe.setDamage(15);
            break;

        }

    }

}
