using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text healthText, blueCrystalText, yellowCrystalText, redCrystalText;
    public player player; 

    // Update is called once per frame
    public void UpdateMenu()
    {
        healthText.text = player.hitPoint.ToString() + "/" +player.maxHitpoint.ToString();
        blueCrystalText.text = GameManager.instance.blue_crystals.ToString();
        yellowCrystalText.text = GameManager.instance.yellow_crystals.ToString();;
        redCrystalText.text = GameManager.instance.red_crystals.ToString();;
    }
}
