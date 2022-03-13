using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web_Projectile : Collidable
{
    public Rigidbody2D rb;
    float speed = 2.5f;

    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(rb.velocity == Vector2.zero)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if(coll.name == "Enemy_Spider")
                return;
            rb.velocity = Vector2.zero;
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("RecieveDamage", dmg);

            Destroy(gameObject);
        }
        else
        if(coll.tag == "Wall")
        {
            rb.velocity = Vector2.zero;
            Destroy(gameObject);
        }
        else
        if(coll.name == "Weapon")
        {
            Destroy(gameObject);
        }
    }
}
