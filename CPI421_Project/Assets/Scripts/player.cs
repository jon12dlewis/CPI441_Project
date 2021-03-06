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
    public GameObject GameOverMenu;

    public Transform startingPoint;
    private float coolDown = 1.5f;
    private float lastChange;

    public Animator animator;

    public int discoveryLevel = 0;

    public float moveSpeed = 1f; 

    Vector2 movement; 
    Vector2 direction = new Vector2(0.0f, -1.0f);

    Vector2 playerPosition;

    public static player instance;
    private void Awake()
    {
        if(player.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    protected override void Start()
    {
        base.Start();
        //DontDestroyOnLoad(gameObject);
        playerPosition = transform.position;
        //startingPoint = transform;
        //weapon.SetActive(false);
        //pickaxe.SetActive(true);
        //bow.SetActive(false);
        transform.position = startingPoint.position;
    }


    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = transform.position;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (hitPoint > 0) {
            animator.SetBool("dead", false);    // panic fix
        }

        // if(mousePos.x > playerPosition.x + 1.5)
        // {
        //     direction.x = 1;
        //     direction.y = 0;
        // }
        // else
        // if(mousePos.x < playerPosition.x - 1.5)
        // {
        //     direction.x = -1;
        //     direction.y = 0;
        // }
        // else
        // if(mousePos.y > playerPosition.y + 1.5)
        // {
        //     direction.x = 0;
        //     direction.y = 1;
        // }
        // else
        // if(mousePos.y < playerPosition.y - 1.5)
        // {
        //     direction.x = 0;
        //     direction.y = -1;

        // }

        // animator.SetFloat("horizontal", direction.x);
        // animator.SetFloat("vertical", direction.y);

        // animator.SetFloat("idle_horizontal", direction.x);
        // animator.SetFloat("idle_vertical", direction.y);

        // animator.SetFloat("speed", movement.sqrMagnitude);

        if(Input.GetKey(KeyCode.Alpha1) && (Time.time - lastChange > coolDown))
        {
            //weapon.SetActive(false);
            //pickaxe.SetActive(true);
            //bow.SetActive(false);
            lastChange = Time.time;
            //weapon.GetComponent<BoxCollider2D>().enabled = false;
            weapon.GetComponent<Weapon>().isEquipped(false);
            //pickaxe.GetComponent<BoxCollider2D>().enabled = true;
            pickaxe.GetComponent<PickAxe>().isEquipped(true);
            bow.GetComponent<Bow>().isEquipped(false);
            bow.GetComponent<SpriteRenderer>().enabled = false;

            //sword.SetTrigger("Sheath");
            pickAxe.SetTrigger("Idle");
        }
        else
        if(Input.GetKey(KeyCode.Alpha2) && (Time.time - lastChange > coolDown))
        {
            /*
            weapon.SetActive(true);
            pickaxe.SetActive(false);
            bow.SetActive(false);
            */
            lastChange = Time.time;
            //weapon.GetComponent<BoxCollider2D>().enabled = true;
            weapon.GetComponent<Weapon>().isEquipped(true);
            //pickaxe.GetComponent<BoxCollider2D>().enabled = false;
            pickaxe.GetComponent<PickAxe>().isEquipped(false);
            bow.GetComponent<Bow>().isEquipped(false);
            bow.GetComponent<SpriteRenderer>().enabled = false;

            //pickAxe.SetTrigger("Sheath");
            sword.SetTrigger("Idle");
        }
        else
        if(Input.GetKey(KeyCode.Alpha3) && (Time.time - lastChange > coolDown))
        {
            /*
            weapon.SetActive(false);
            pickaxe.SetActive(false);
            bow.SetActive(true);
            */
            lastChange = Time.time;
            //weapon.GetComponent<BoxCollider2D>().enabled = false;
            weapon.GetComponent<Weapon>().isEquipped(false);
            //pickaxe.GetComponent<BoxCollider2D>().enabled = false;
            pickaxe.GetComponent<PickAxe>().isEquipped(false);
            bow.GetComponent<Bow>().isEquipped(true);
            bow.GetComponent<SpriteRenderer>().enabled = true;

            //pickAxe.SetTrigger("Sheath");
            //sword.SetTrigger("Idle");
        }

        // if (Input.GetMouseButton(0))
        // {
        //     animator.SetTrigger("Attack");
        // }

        //UpdateMotor(new Vector3(movement.x,movement.y,0));

    }

    private void FixedUpdate()
    {
    
        UpdateMotor(new Vector3(movement.x * moveSpeed ,movement.y * moveSpeed,0));
    } 

    public void addHealth()
    {
        hitPoint += 1;
    }

    public void setSpeed(float Speed)
    {
        moveSpeed = Speed;              // Default is 2f
    }

    public void setDiscovery(int discovery)
    {
        discoveryLevel = discovery;
    }

    public int getDiscovery()
    {
        return discoveryLevel;
    }


    protected override void Death()
    {
        //Application.Quit();
        //hitPoint = maxHitpoint;
        moveSpeed = 0;
        animator.SetBool("dead", true);
        GameManager.instance.SaveState();
        GameOverMenu = GameObject.Find("GameOverScreen");
        GameOverMenu.GetComponent<Animator>().SetTrigger("GameOver");
        //Time.timeScale = 0;
        //UnityEngine.SceneManagement.SceneManager.LoadScene("HomeBase");
        //transform.position = startingPoint.position;
    
    }
    
}
