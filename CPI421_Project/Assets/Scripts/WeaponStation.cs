using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStation : Collidable
{

    public GameObject weaponStation;

    public Text statsText, requirementsText;

    public int weapon = 1;

    public int max = 3;
    public int min = 1;

    // Start is called before the first frame update
protected override void Start()
    {
        base.Start();
        statsText.text = "Stats:\nAttack: +3";
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
            Debug.Log("Start menu");
            weaponStation.SetActive(true);

        }
        else
        {
            weaponStation.SetActive(false);
        }

    }

    public void nextWeapon()
    {
        weapon += min;
        Debug.Log("Switching to Helmet: " + weapon);
        if(weapon > max)
        {
            weapon = min;
        }
    }

    public void previousWeapon()
    {
        weapon -= min;
        Debug.Log("Switching to Helmet: " + weapon);
        if(weapon < min)
        {
            weapon = max;
        }
    }

    public void craftWeapon1()
    {
        if(GameManager.instance.GetYellowCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(10);
            GameManager.instance.weapons[0] = 1;
            Debug.Log("Crafting Sword 1");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftWeapon2()
    {
        if(GameManager.instance.GetYellowCrystal() >= 15 && GameManager.instance.GetBlueCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(15);
            GameManager.instance.TakeBlueCrystal(10);
            GameManager.instance.weapons[1] = 1;
            Debug.Log("Crafting Sword 2");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftWeapon3()
    {
        if(GameManager.instance.GetYellowCrystal() >= 30 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 5)
        {
            GameManager.instance.TakeYellowCrystal(30);
            GameManager.instance.TakeBlueCrystal(20);
            GameManager.instance.TakeRedCrystal(5);
            GameManager.instance.weapons[2] = 1;
            Debug.Log("Crafting Sword 3");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftPickAxe1()
    {
        if(GameManager.instance.GetYellowCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(10);
            GameManager.instance.pickaxes[0] = 1;

            Debug.Log("Crafting Pickaxe 1");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftPickAxe2()
    {
        if(GameManager.instance.GetYellowCrystal() >= 15 && GameManager.instance.GetBlueCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(15);
            GameManager.instance.TakeBlueCrystal(10);
            GameManager.instance.pickaxes[1] = 1;
            Debug.Log("Crafting Pickaxe 2");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftPickAxe3()
    {
        if(GameManager.instance.GetYellowCrystal() >= 30 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 5)
        {
            GameManager.instance.TakeYellowCrystal(30);
            GameManager.instance.TakeBlueCrystal(20);
            GameManager.instance.TakeRedCrystal(5);
            GameManager.instance.pickaxes[2] = 1;

            Debug.Log("Crafting Pickaxe 3");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftBow1()
    {
        if(GameManager.instance.GetYellowCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(10);
            GameManager.instance.bows[0] = 1;
            Debug.Log("Crafting Bow 1");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftBow2()
    {
        if(GameManager.instance.GetYellowCrystal() >= 15 && GameManager.instance.GetBlueCrystal() >= 10)
        {
            GameManager.instance.TakeYellowCrystal(15);
            GameManager.instance.TakeBlueCrystal(10);
            GameManager.instance.bows[1] = 1;

            Debug.Log("Crafting Bow 2");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void craftBow3()
    {
        if(GameManager.instance.GetYellowCrystal() >= 30 && GameManager.instance.GetBlueCrystal() >= 20 && GameManager.instance.GetRedCrystal() >= 5)
        {
            GameManager.instance.TakeYellowCrystal(30);
            GameManager.instance.TakeBlueCrystal(20);
            GameManager.instance.TakeRedCrystal(5);
            GameManager.instance.bows[2] = 1;

            Debug.Log("Crafting Bow 3");
        }
        else
        {
            Debug.Log("Not Enough Crystals");
        }
    }

    public void updateStats()
    {
        switch(weapon)
        {
            case 1:
                    statsText.text = "Stats:\nDamage: +3";
            break;
            case 2:
                    statsText.text = "Stats:\nDamage: +10";
            break;
            case 3:
                    statsText.text = "Stats:\nDamage: +15";
            break;
        }
    }

    public void updateRequirements()
    {
        switch(weapon)
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

    public void resetWeapon()
    {
        weapon = 1;
    }

}
