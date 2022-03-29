using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStation : Collidable
{

    public GameObject weaponStation;

    // Start is called before the first frame update
protected override void Start()
    {
        base.Start();
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

        /*
            if(!collected)
            {
                collected = true;
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                transform.localScale = new Vector3(0.3f,0.3f,1);
                GameManager.instance.GiveBlueCrystal(crystalAmount);
                //Debug.Log("Grant " + mulaAmount + " mula!");
                GameManager.instance.ShowText("+ " + crystalAmount + " Crystals!", 25, Color.yellow, transform.position , Vector3.up * 25, 1.0f);

                coin1.Play(0);
                positive.Play(0);
            } 
            */
    }
}
