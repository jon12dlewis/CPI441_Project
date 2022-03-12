using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Mover
{
    // Expierence
    public int xpValue = 1;

    public float triggerLength = 1;
    public float chaseLength = 5;

    private bool chasing;
    private bool collideWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    // AI
    public Transform target;
    NavMeshAgent agent;
    public Vector3 agentSpeed;
    Vector2 movement = new Vector2(0.0f, -1.0f);
    Vector2 direction = new Vector2(0.0f, -1.0f);
    public Animator animator;
    protected float stagger = 2f;
    protected float staggerTime;
    public bool attack;
    int facing = 0;
    public GameObject arrow;

    protected float attackTime = 2.0f;
    //protected float webTime = 2.0f;
    protected float lastAttack;
    protected float webIdleTime;
    protected float idleTime = 2.0f;

    // HitBox
    public ContactFilter2D filter;
    private BoxCollider2D hitBox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        target = GameObject.Find("Player").transform;
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitBox = transform.GetChild(0).GetComponent<BoxCollider2D>();

        agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
        agentSpeed = agent.velocity;
        staggerTime = stagger;
        webIdleTime = idleTime;
    }

    private void FixedUpdate()
    {
        // check for overlaps
        collideWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);

        for(int i = 0; i < hits.Length; i++)
        {
            if(hits[i] == null)
                continue;

            if(hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collideWithPlayer = true;
            }

            hits[i] = null;
        }
    }

    private void Update()
    {
        agentSpeed = agent.velocity;
        movement.x = agentSpeed.x;
        movement.y = agentSpeed.y;

        webIdleTime -= Time.deltaTime;

        if(webIdleTime <= 0)
        {
            agent.isStopped = false;
        }

        if(target != null)
        {
            if(wasHit == true)
            {
                staggerTime -= Time.deltaTime;
                agent.velocity = Vector3.zero;
                if(staggerTime <= 0)
                {
                    staggerTime = stagger;
                    wasHit = false;
                }
            }

            if(Vector3.Distance(playerTransform.position, this.transform.position) <= 1.5f) 
            {
                if(Time.time - lastAttack > attackTime)
                {
                    lastAttack = Time.time;
                    animator.SetTrigger("attack");
                }
                agent.SetDestination(target.position);
            }
            else                                                                                                                                                     // add to make the enemy only fire one shot then leave
            if(Vector3.Distance(playerTransform.position, this.transform.position) > 4f && Vector3.Distance(playerTransform.position, this.transform.position) < 5f) //  && Time.time - lastAttack > attackTime)
            {
                if(Time.time - lastAttack > attackTime)
                {
                    lastAttack = Time.time;

                    webIdleTime = idleTime;
                    agent.isStopped = true;

                    switch(facing)
                    {
                        case 0:
                            ShootDown();
                            break;
                        case 1:
                            ShootUp();
                            break;
                        case 2:
                            ShootRight();
                            break;
                        case 3:
                            ShootLeft();
                            break;
                    }

                    animator.SetTrigger("web_attack");
                }
                agent.SetDestination(target.position);
            }
            else
            if(Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
            {
                chasing = Vector3.Distance(playerTransform.position, startingPosition) < triggerLength;

                if(chasing)
                {
                    if(!collideWithPlayer)
                    {
                        agent.SetDestination(target.position);
                    }
                }
                else
                {
                    //UpdateMotor(startingPosition - transform.position);
                    agent.SetDestination(startingPosition);
                }
            }
            else
            {
                //UpdateMotor(startingPosition - transform.position);
                agent.SetDestination(startingPosition);
                chasing = false;
            }

            if(agentSpeed.x > 0.2f)
            {
                direction.x = 1;
                direction.y = 0;
                facing = 2;
            }
            else
            if(agentSpeed.x < -0.2f)
            {
                direction.x = -1;
                direction.y = 0;
                facing = 3;
            }
            else
            if(agentSpeed.y > 0.2f)
            {
                direction.x = 0;
                direction.y = 1;
                facing = 1;
            }
            else
            if(agentSpeed.y < -0.2f)
            {
                direction.x = 0;
                direction.y = -1;
                facing = 0;
            }
        }

        

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);

        animator.SetFloat("idle_horizontal", direction.x);
        animator.SetFloat("idle_vertical", direction.y);

        animator.SetFloat("speed", movement.sqrMagnitude);

    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.expierence += xpValue;
        GameManager.instance.ShowText("+ " + xpValue + "xp", 60, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }

    void ShootUp()
    {
        Vector3 newRot = new Vector3(0,0,90);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, transform.position, rot);
    }
    void ShootDown()
    {
        Vector3 newRot = new Vector3(0,0,270);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, transform.position, rot);
    }
    void ShootLeft()
    {
        Vector3 newRot = new Vector3(0,0,0);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, transform.position, rot);
    }
    void ShootRight()
    {
        Vector3 newRot = new Vector3(0,0,180);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, transform.position, rot);
    }
}
