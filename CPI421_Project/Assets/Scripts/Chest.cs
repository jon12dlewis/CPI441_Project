using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int crystalAmount = 5;
    [SerializeField] AudioSource coin1;
    [SerializeField] AudioSource positive;


    // Start is called before the first frame update
    protected override void OnCollect()
    {
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
    }

}
