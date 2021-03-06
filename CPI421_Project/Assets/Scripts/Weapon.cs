using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon :Collidable
{
    // Damage struct
    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    // Swing 
    private Animator anim;
    private float coolDown = 1f;
    private float lastSwing;
    private bool equipped;
    private Transform Player;

    // Directions
    int direction = 0;
    Vector3 buffer = new Vector3(0,1,0);
    private Vector2 playerPosition;

    // SFX
    [SerializeField] AudioSource hitSound;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Player = GameObject.Find("Player").transform;
    }

    protected override void Update()
    {
        base.Update();  // Need to check collision

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = Player.position;


        if(mousePos.y > playerPosition.y + 1.5)
        {
            direction = 1;
        }
        else
        if(mousePos.y < playerPosition.y - 1.5)
        {
            direction = 0;
        }
        
        if(mousePos.x > playerPosition.x + 1.5)
        {
            direction = 2;
        }
        else
        if(mousePos.x < playerPosition.x - 1.5)
        {
            direction = 3;
        }
        

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
                            Swing();
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
        if(coll.tag == "Fighter")
        {
            if(coll.name == "Player")
                return;

            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            if (hitSound != null) hitSound.Play(0);
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

    private void Swing()
    {
        anim.SetTrigger("SwingSide");
    }

    private void SwingLeft()
    {
        anim.SetTrigger("SwingLeft");
    }

    public void setDamage(int selected)
    {
        damagePoint = selected;
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
