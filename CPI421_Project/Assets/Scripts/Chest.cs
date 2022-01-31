using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int mulaAmount = 5;

    // Start is called before the first frame update
    protected override void OnCollect()
    {
            if(!collected)
            {
                collected = true;
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                //Debug.Log("Grant " + mulaAmount + " mula!");
                GameManager.instance.ShowText("+ " + mulaAmount + " mula!", 25, Color.yellow, transform.position , Vector3.up * 25, 1.0f);
            } 
    }

}
