using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingStation : Collidable
{

    public GameObject craftingStation;

    public Text statsText, requirementsText;

    public int armor = 1;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        statsText.text = "Stats:\nDefense: +3";
        requirementsText.text = "Requirements:\nYellow Crystals: 10 (" + GameManager.instance.GetYellowCrystal() + ")";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();  // Need to check collision
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player")
        {
            craftingStation.SetActive(true);
        } 
    }

    public void nextArmor()
    {
        armor += 1;
        Debug.Log("Switching to Helmet: " + armor);
        if(armor > 3)
        {
            armor = 1;
        }
    }

    public void previousArmor()
    {
        armor -= 1;
        Debug.Log("Switching to Helmet: " + armor);
        if(armor < 1)
        {
            armor = 3;
        }
    }

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

}
