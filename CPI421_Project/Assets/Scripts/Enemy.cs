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

    // HitBox
    public ContactFilter2D filter;
    private BoxCollider2D hitBox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitBox = transform.GetChild(0).GetComponent<BoxCollider2D>();

        agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
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
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.expierence += xpValue;
        GameManager.instance.ShowText("+ " + xpValue + "xp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
