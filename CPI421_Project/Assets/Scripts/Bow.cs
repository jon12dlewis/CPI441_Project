using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Animator animator;
    public GameObject arrow;
    Vector2 direction = new Vector2(0.0f, -1.0f);
    int facing = 0;
    private float coolDown = 1.5f;
    private float lastShot;
    [SerializeField] AudioSource fireSound;
    private SpriteRenderer spriteRenderer;
    private bool equipped;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(mousePos.x > this.transform.position.x + 1.5)
        {
            direction .x = 1;
            direction.y = 0;
            facing = 3;
        }
        else
        if(mousePos.x < this.transform.position.x - 1.5)
        {
            direction.x = -1;
            direction.y = 0;
            facing = 2;
        }
        else
        if(mousePos.y > this.transform.position.y + 1.5)
        {
            direction.x = 0;
            direction.y = 1;
            facing = 1;
        }
        else
        if(mousePos.y < this.transform.position.y - 1.5)
        {
            direction.x = 0;
            direction.y = -1;
            facing = 0;
        }

    
        if(equipped)
        {
            if(Input.GetKeyDown(KeyCode.Space) && GameManager.instance.arrows > 0)
            {
                if(Time.time - lastShot > coolDown)
                {
                    lastShot = Time.time;
                    fireSound.Play(0);

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
            }
        }

        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);
    }

    void ShootUp()
    {
        GameManager.instance.takeArrow(1);
        Vector3 newRot = new Vector3(0,0,90);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, transform.position, rot);
    }
    void ShootDown()
    {
        GameManager.instance.takeArrow(1);
        Vector3 newRot = new Vector3(0,0,270);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, transform.position, rot);
    }
    void ShootLeft()
    {
        GameManager.instance.takeArrow(1);
        Vector3 newRot = new Vector3(0,0,0);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, transform.position, rot);
    }
    void ShootRight()
    {
        GameManager.instance.takeArrow(1);
        Vector3 newRot = new Vector3(0,0,180);
        Quaternion rot = Quaternion.Euler(newRot); 
        Instantiate(arrow, transform.position, rot);
    }

    public void SetLevelAnimation(int level)
    {
        switch(level)
        {
            case 1:
                animator.SetTrigger("lvl1");
            break;
            case 2:
                animator.SetTrigger("lvl2");
            break;
            case 3:
                animator.SetTrigger("lvl3");
            break;
        }
    }

    public void isEquipped(bool choice)
    {
        equipped = choice;
    }


    /*
    public void setDamage(int selected)
    {
        damagePoint = selected;
    }
    */
    public void setImage(Sprite selected)
    {
        spriteRenderer.sprite = selected;
    }

}
