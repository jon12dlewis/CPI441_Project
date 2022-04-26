using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int crystalAmount = 5;
    [SerializeField] AudioSource coin1;
    [SerializeField] AudioSource positive;
    private player player;

    void start()
    {
        player = GameObject.Find("Player").GetComponent<player>();
    }


    // Start is called before the first frame update
    protected override void OnCollect()
    {
            if(!collected)
            {
                collected = true;
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                transform.localScale = new Vector3(0.3f,0.3f,1);

                int yellow_crystals_chance = Random.Range(1 + player.getDiscovery() , 10);
                int blue_crystals_chance = Random.Range(1 + player.getDiscovery() , 20);
                int red_crystals_chance = Random.Range(1 + player.getDiscovery() , 50);
                int arrow_chance = Random.Range(1 + player.getDiscovery() , 20);

                if(yellow_crystals_chance == 9)
                {
                    int crystalAmount = Random.Range(1 + player.getDiscovery() , 10 + player.getDiscovery());
                    GameManager.instance.GiveYellowCrystal(crystalAmount);
                }

                if(blue_crystals_chance == 19)
                {
                    int crystalAmount = Random.Range(1 + player.getDiscovery() , 7 + player.getDiscovery());
                    GameManager.instance.GiveBlueCrystal(crystalAmount);
                }

                if(red_crystals_chance == 49)
                {
                    int crystalAmount = Random.Range(1 + player.getDiscovery() , 5 + player.getDiscovery());
                    GameManager.instance.GiveRedCrystal(crystalAmount);
                }

                if(arrow_chance == 19)
                {
                    GameManager.instance.arrows += 5;
                }

                
                //Debug.Log("Grant " + mulaAmount + " mula!");
                GameManager.instance.ShowText("+ " + crystalAmount + " Crystals!", 25, Color.yellow, transform.position , Vector3.up * 25, 1.0f);

                coin1.Play(0);
                positive.Play(0);
            } 
    }

}
