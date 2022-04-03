using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text healthText, blueCrystalText, yellowCrystalText, redCrystalText;
    public player player; 
    public Sprite[] pickAxeImage, weaponImage, bowImage;
    private Sprite pickAxeDisplay, weaponDisplay, bowDisplay;
    public Weapon weapon;
    public PickAxe pickAxe;

    int weaponSelected = 1;
    int pickAxeSelected = 1;
    int bowSelected = 1;

    // Update is called once per frame
    public void UpdateMenu()
    {
        healthText.text = player.hitPoint.ToString() + "/" +player.maxHitpoint.ToString();
        blueCrystalText.text = GameManager.instance.blue_crystals.ToString();
        yellowCrystalText.text = GameManager.instance.yellow_crystals.ToString();;
        redCrystalText.text = GameManager.instance.red_crystals.ToString();;
    }

    public void increaseWeapon()
    {
        weaponSelected += 1;
        if(weaponSelected > 3)
        {
            weaponSelected = 1;
        }
    }

    public void decreaseWeapon()
    {
        weaponSelected -= 1;
        if(weaponSelected < 1)
        {
            weaponSelected = 3;
        }
    }

    public void UpdateSword()
    {
        weaponDisplay = weaponImage[weaponSelected-1];
    }

    public void UpdateBow()
    {

    }

    public void UpdatePickAxe()
    {

    }

}
