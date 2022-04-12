using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToBase : Collidable
{

    private Animator door;
    private float coolDown = 5f;
    private float lastShot;
    private bool canLeave = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        door = GameObject.FindGameObjectWithTag("door").GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

                if(Time.time - lastShot > coolDown)
                {
                    lastShot = Time.time;
                    canLeave = true;
                }  

    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if(coll.name == "Player")
            {

                if(canLeave)
                {
                    canLeave = false;
                    door.SetTrigger("active");
                    lastShot = Time.time;
                }   

            }

        }
    }

}
