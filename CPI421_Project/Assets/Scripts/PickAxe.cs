using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : Collidable
{
    // Damage struct
    public int damagePoint = 1;
    public float pushForce = 0.0f;

    // Upgrade
    public int pickAxeLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing 
    private Animator anim;
    private float coolDown = 0.5f;
    private float lastSwing;
    int direction = 0;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Sheath");
    }

    protected override void Update()
    {
        base.Update();  // Need to check collision

        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > coolDown)
            {
                lastSwing = Time.time;
                Swing();
            }   
        }
        */

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(mousePos.y > this.transform.position.y + 1.5)
        {
            direction = 1;
        }
        else
        if(mousePos.y < this.transform.position.y - 1.5)
        {
            direction = 0;
        }
        
        if(mousePos.x > this.transform.position.x + 1.5)
        {
            direction = 2;
        }
        else
        if(mousePos.x < this.transform.position.x - 1.5)
        {
            direction = 3;
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > coolDown)
            {
                lastSwing = Time.time;

                switch(direction)
                {
                    case 0:
                        SwingDown();
                        break;
                    case 1:
                        SwingUp();
                        break;
                    case 2:
                        SwingRight();
                        break;
                    case 3:
                        SwingLeft();
                        break;

                }

                //Swing();
            }   
        }

    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Crystal" || coll.tag == "Fighter")
        {
            if(coll.name == "Player")
                return;

            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("RecieveDamage", dmg);
        }
    }

    private void SwingUp()
    {
        anim.SetTrigger("SwingUp");
    }

    private void SwingDown()
    {
        anim.SetTrigger("SwingDown");
    }

    private void SwingLeft()
    {
        anim.SetTrigger("SwingLeft");
    }

    private void SwingRight()
    {
        anim.SetTrigger("SwingRight");
    }
}
