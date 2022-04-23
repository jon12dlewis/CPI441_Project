using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_Bottoms : MonoBehaviour
{
    Vector2 direction = new Vector2(0.0f, -1.0f);
    Vector2 playerPosition;
    private Animator animator;
    Vector2 movement;
    private Transform Player;

    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = Player.position;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(mousePos.x > playerPosition.x + 1.5)
        {
            direction.x = 1;
            direction.y = 0;
        }
        else
        if(mousePos.x < playerPosition.x - 1.5)
        {
            direction.x = -1;
            direction.y = 0;
        }
        else
        if(mousePos.y > playerPosition.y + 1.5)
        {
            direction.x = 0;
            direction.y = 1;
        }
        else
        if(mousePos.y < playerPosition.y - 1.5)
        {
            direction.x = 0;
            direction.y = -1;
        }

        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);

        animator.SetFloat("idle_horizontal", direction.x);
        animator.SetFloat("idle_vertical", direction.y);

        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    public void SetLevelAnimation(int level)
    {
        animator.SetInteger("level", level);
    }

}
