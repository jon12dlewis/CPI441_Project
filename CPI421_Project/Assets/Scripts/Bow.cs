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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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

        if(Input.GetKeyDown(KeyCode.Space))
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

        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.y);
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
