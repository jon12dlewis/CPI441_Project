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
    private float coolDown = 1.5f;
    private float lastSwing;
    int direction = 0;
    bool equipped = false;
    private Transform Player;

    Vector2 dir = new Vector2(0.0f, -1.0f);
    private Vector2 playerPosition;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Sheath");
        Player = GameObject.Find("Player").transform;
    }

    protected override void Update()
    {
        base.Update();  // Need to check collision
        playerPosition = Player.position;
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

        if(mousePos.y > playerPosition.y + 1.5)
        {
            direction = 1;
            dir.x = 0;
            dir.y = 1;
        }
        else
        if(mousePos.y < playerPosition.y - 1.5)
        {
            direction = 0;
            dir.x = 0;
            dir.y = -1;
        }
        
        if(mousePos.x > playerPosition.x + 1.5)
        {
            direction = 2;
            dir.x = 1;
            dir.y = 0;
        }
        else
        if(mousePos.x < playerPosition.x - 1.5)
        {
            direction = 3;
            dir.x = -1;
            dir.y = 0;
        }

        anim.SetFloat("horizontal", dir.x);
        anim.SetFloat("vertical", dir.y);
        
        if(equipped)
        {
            if (Input.GetMouseButton(0))
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
        anim.SetTrigger("Swing");
        
    }

    private void SwingDown()
    {
        anim.SetTrigger("Swing");
    }

    private void SwingLeft()
    {
        anim.SetTrigger("Swing");
    }

    private void SwingRight()
    {
        anim.SetTrigger("Swing");
    }

    public void setDamage(int selected)
    {
        damagePoint = selected;
    }

    public void setLevel(int level)
    {
        anim.SetInteger("pickAxeLvl", level);
    }

    public void setImage(Sprite selected)
    {
        spriteRenderer.sprite = selected;
    }

    public void isEquipped(bool choice)
    {
        equipped = choice;
    }
}
