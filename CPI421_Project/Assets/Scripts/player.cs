using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Mover
{
    public Animator pickAxe;
    public Animator sword;

    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            sword.SetTrigger("Sheath");
            pickAxe.SetTrigger("Idle");
        }
        else
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            pickAxe.SetTrigger("Sheath");
            sword.SetTrigger("Idle");
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(mousePos.y > this.transform.position.y + 1.5)
        {
            GetComponent<SpriteRenderer>().sprite = up;
        }
        else
        if(mousePos.y < this.transform.position.y - 1.5)
        {
            GetComponent<SpriteRenderer>().sprite = down;
        }
        
        if(mousePos.x > this.transform.position.x + 1.5)
        {
            GetComponent<SpriteRenderer>().sprite = right;
        }
        else
        if(mousePos.x < this.transform.position.x - 1.5)
        {
            GetComponent<SpriteRenderer>().sprite = right;
        }

    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        
        UpdateMotor(new Vector3(x,y,0));
    } 

    protected override void Death()
    {
        //Application.Quit();
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
    
}
