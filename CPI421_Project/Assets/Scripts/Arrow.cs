using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Collidable
{
    //public Rigidbody2D rb;
    float speed = 10f;

    public int damagePoint = 1;
    public float pushForce = 2.0f;

    // SFX
    [SerializeField] AudioSource impactSound;
    [SerializeField] DeathSound deathSoundPrefab;
    [SerializeField] float audioFalloff;    // how far away is it weird to hear the arrow break

    Vector2 startPosition;
    bool mute;
    float distanceTraveled;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //rb.velocity = transform.right * speed;
        //transform.Translate( speed * Time.deltaTime, 0, 0);
        startPosition = transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.Translate( speed * Time.deltaTime, 0, 0);

        distanceTraveled = Mathf.Abs(Vector2.Distance(startPosition, transform.position));
        if (distanceTraveled > audioFalloff) mute = true;
    }

    public void setDamage(int damage)
    {
        damagePoint = damage;
    }
    

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if(coll.name == "Player")
                return;
            //rb.velocity = Vector2.zero;
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
            //rb.velocity = Vector2.zero;
            Destroy(gameObject);
        }
        else
        if(coll.name == "web_projectile(Clone)")
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy() {
        if (gameObject.scene.isLoaded) {
            if (!mute) {
                var temp = Instantiate(deathSoundPrefab);
                temp.gameObject.SendMessage("SetAudioSource", impactSound);
            }
        }
    }
}
