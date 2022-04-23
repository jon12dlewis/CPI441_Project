using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartPickUp : Collidable
{
    private player Player;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Player = GameObject.Find("Player").GetComponent<player>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }


    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if(coll.name == "Player" && Player.hitPoint < Player.maxHitpoint)
            {
                //if (hitSound != null) hitSound.Play(0);
                Player.addHealth();
                Destroy(gameObject);
            }


        }
    }

}
