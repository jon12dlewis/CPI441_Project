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
    public GameObject heart;
    public GameObject arrowDrop;

    // AI
    public Transform target;
    NavMeshAgent agent;
    public Vector3 agentSpeed;
    Vector2 movement = new Vector2(0.0f, -1.0f);
    Vector2 direction = new Vector2(0.0f, -1.0f);
    private Animator animator;
    protected float stagger = 2f;
    protected float staggerTime;
    public bool attack;
    int facing = 0;
    public GameObject arrow;
    public Transform fireSpot;
    private bool canShoot = false;

    protected float attackTime = 2.0f;
    //protected float webTime = 2.0f;
    protected float lastAttack;
    protected float webIdleTime;
    protected float idleTime = 2.0f;

    protected float shotTime = 0.5f;
    protected float idle;

    // HitBox
    public ContactFilter2D filter;
    private BoxCollider2D hitBox;
    private Collider2D[] hits = new Collider2D[10];

    // SFX
    [SerializeField] AudioSource attackSound;
    MusicController musicController;

    protected override void Start()
    {
        base.Start();
        target = GameObject.Find("Player").transform;
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitBox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
        agentSpeed = agent.velocity;
        staggerTime = stagger;
        webIdleTime = idleTime;
        idle = shotTime;
    }

    void Awake() {
        GameObject temp = GameObject.FindGameObjectWithTag("GameController");
        musicController = temp.GetComponent<MusicController>();
        musicController.EnemyEnable();
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
        idle -= Time.deltaTime;

        if (chasing) {
            musicController.InCombat(this.gameObject);
        }

        if(webIdleTime <= 0)
        {
            agent.isStopped = false;
        }

        if(idle <= 0 && canShoot)
        {
            canShoot = false;
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
                    attackSound.Play();
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
                    animator.SetTrigger("web_attack");
                    idle = shotTime;
                    canShoot = true;
 
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

            if(agentSpeed.x > 0.1f)
            {
                direction.x = 1;
                direction.y = 0;
                facing = 2;
            }
            else
            if(agentSpeed.x < -0.1f)
            {
                direction.x = -1;
                direction.y = 0;
                facing = 3;
            }
            else
            if(agentSpeed.y > 0.1f)
            {
                direction.x = 0;
                direction.y = 1;
                facing = 0;
            }
            else
            if(agentSpeed.y < -0.1f)
            {
                direction.x = 0;
                direction.y = -1;
                facing = 1;
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
        musicController.EnemyDisable(this.gameObject);
        int val = Random.Range(1, 5);
        int val2 = Random.Range(1, 5);
        if(val == 1)
        {
            Vector3 newRot = new Vector3(0,0,0);
            Quaternion rot = Quaternion.Euler(newRot); 
            Instantiate(heart, transform.position, rot);
        }

        if(val2 == 4)
        {
            Vector3 newRot = new Vector3(0,0,0);
            Quaternion rot = Quaternion.Euler(newRot); 
            Instantiate(arrowDrop, transform.position, rot);
        }


        Destroy(gameObject);
        //GameManager.instance.expierence += xpValue;
        //GameManager.instance.ShowText("+ " + xpValue + "xp", 60, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }

    void ShootUp()
    {
        Vector3 newRot = new Vector3(0,0,90);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, fireSpot.position, rot);
    }
    void ShootDown()
    {
        Vector3 newRot = new Vector3(0,0,270);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, fireSpot.position, rot);
    }
    void ShootLeft()
    {
        Vector3 newRot = new Vector3(0,0,0);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, fireSpot.position, rot);
    }
    void ShootRight()
    {
        Vector3 newRot = new Vector3(0,0,90);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, fireSpot.position, rot);
    }
}
