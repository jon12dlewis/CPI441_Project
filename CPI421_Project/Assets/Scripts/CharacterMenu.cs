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

    public GameObject weapon;
    public GameObject pickAxe;
    public GameObject bow;

    int weaponSelected = 1;
    int pickAxeSelected = 1;
    int bowSelected = 1;
    int helmetSelected = 1;
    int chestSelected = 1;
    int legsSelected = 1;

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

        weapon.GetComponent<Weapon>().setImage(weaponImage[weaponSelected-1]);

        switch(weaponSelected)
        {
            case 1:
                weaponDamage.text = "5";
                weapon.GetComponent<Weapon>().setDamage(5);
            break;
            case 2:
                weaponDamage.text = "8";
                weapon.GetComponent<Weapon>().setDamage(8);
            break;
            case 3:
                weaponDamage.text = "15";
                weapon.GetComponent<Weapon>().setDamage(15);
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
        //weapon.GetComponent<Weapon>().setDamage(1);
        weapon.GetComponent<Weapon>().setImage(weaponImage[weaponSelected-1]);

        switch(weaponSelected)
        {
            case 1:
                weaponDamage.text = "5";
                weapon.GetComponent<Weapon>().setDamage(5);
            break;
            case 2:
                weaponDamage.text = "8";
                weapon.GetComponent<Weapon>().setDamage(8);
            break;
            case 3:
                weaponDamage.text = "15";
                weapon.GetComponent<Weapon>().setDamage(15);
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
        bow.GetComponent<Bow>().setImage(bowImage[bowSelected-1]);
        
        switch(bowSelected)
        {
            case 1:
                bowDamage.text = "5";
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
            break;
            case 2:
                bowDamage.text = "8";
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
            break;
            case 3:
                bowDamage.text = "15";
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
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
        bow.GetComponent<Bow>().setImage(bowImage[bowSelected-1]);

        switch(bowSelected)
        {
            case 1:
                bowDamage.text = "5";
                //bow.setDamage(5);
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
            break;
            case 2:
                bowDamage.text = "8";
                //bow.setDamage(8);
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
            break;
            case 3:
                bowDamage.text = "15";
                //bow.setDamage(15);
                bow.GetComponent<Bow>().SetLevelAnimation(bowSelected);
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
        pickAxe.GetComponent<PickAxe>().setImage(pickAxeImage[pickAxeSelected-1]);

        switch(pickAxeSelected)
        {
            case 1:
                pickAxeDamage.text = "5";
                pickAxe.GetComponent<PickAxe>().setDamage(5);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);
            break;
            case 2:
                pickAxeDamage.text = "8";
                pickAxe.GetComponent<PickAxe>().setDamage(8);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);

            break;
            case 3:
                pickAxeDamage.text = "15";
                pickAxe.GetComponent<PickAxe>().setDamage(15);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);
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
        pickAxe.GetComponent<PickAxe>().setImage(pickAxeImage[pickAxeSelected-1]);

        switch(pickAxeSelected)
        {
            case 1:
                pickAxeDamage.text = "5";
                pickAxe.GetComponent<PickAxe>().setDamage(5);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);
            break;
            case 2:
                pickAxeDamage.text = "8";
                pickAxe.GetComponent<PickAxe>().setDamage(8);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);
            break;
            case 3:
                pickAxeDamage.text = "15";
                pickAxe.GetComponent<PickAxe>().setDamage(15);
                pickAxe.GetComponent<PickAxe>().setLevel(pickAxeSelected);
            break;

        }

    }

    public void increaseHelmet()
    {
        helmetSelected += 1;
        if(helmetSelected > 3)
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

public void decreaseHelmet()
    {
        helmetSelected -= 1;
        if(helmetSelected < 1)
        {
            helmetSelected = 3;
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
        chestSelected += 1;
        if(chestSelected > 3)
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

    public void decreaseChest()
    {
        chestSelected -= 1;
        if(chestSelected < 1)
        {
            chestSelected = 3;
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
        legsSelected += 1;
        if(legsSelected > 3)
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

    public void decreaseLegs()
    {
        legsSelected -= 1;
        if(legsSelected < 1)
        {
            legsSelected = 3;
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
