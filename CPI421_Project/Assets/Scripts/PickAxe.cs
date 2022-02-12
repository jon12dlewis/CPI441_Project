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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > coolDown)
            {
                lastSwing = Time.time;
                Swing();
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

    private void Swing()
    {
        anim.SetTrigger("Swing");
    }
}
