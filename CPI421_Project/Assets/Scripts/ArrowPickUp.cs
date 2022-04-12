using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPickUp : Collidable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
            if(coll.name == "Player")
            {
                GameManager.instance.addArrow(1);
                Destroy(gameObject);
            }

        }
    }
}
