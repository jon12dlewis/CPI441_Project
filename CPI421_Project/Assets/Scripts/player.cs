using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Mover
{
    public Animator pickAxe;
    public Animator sword;

    public GameObject weapon;
    public GameObject pickaxe;
    public GameObject bow;

    public Animator animator;

    public float moveSpeed = 2f; 

    Vector2 movement; 
    Vector2 direction = new Vector2(0.0f, -1.0f);

    Vector2 playerPosition;

    protected override void Start()
    {
        base.Start();
        DontDestroyOnLoad(gameObject);
        playerPosition = transform.position;
        weapon.SetActive(false);
        pickaxe.SetActive(true);
        bow.SetActive(false);
    }


    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = transform.position;

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

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon.SetActive(false);
            pickaxe.SetActive(true);
            bow.SetActive(false);
            //sword.SetTrigger("Sheath");
            pickAxe.SetTrigger("Idle");
        }
        else
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon.SetActive(true);
            pickaxe.SetActive(false);
            bow.SetActive(false);
            //pickAxe.SetTrigger("Sheath");
            sword.SetTrigger("Idle");
        }
        else
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon.SetActive(false);
            pickaxe.SetActive(false);
            bow.SetActive(true);
            //pickAxe.SetTrigger("Sheath");
            //sword.SetTrigger("Idle");
        }

    }

    private void FixedUpdate()
    {
    
        UpdateMotor(new Vector3(movement.x,movement.y,0));
    } 

    protected override void Death()
    {
        //Application.Quit();
        GameManager.instance.SaveState();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Cave_1");
    }
    
}
