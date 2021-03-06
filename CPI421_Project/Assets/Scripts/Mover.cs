using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;

    protected Vector3 moveDelta;

    protected RaycastHit2D hit;

    protected float ySpeed = 1.5f;
    protected float xSpeed = 2f;

    //Vector3 mousePos;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }


    protected virtual void UpdateMotor(Vector3 input)
    {
        // reset movedelta
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        // Swap sprite direction

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        /*
        
        if(mousePos.x > this.transform.position.x)
        {
            transform.localScale = new Vector3(-0.3f,0.3f,0.3f);
        }
        else 
        if(mousePos.x < this.transform.position.x)
        {
            transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        }

        */

        /*
        if(transform.name == "Enemy")
        {
            transform.localScale = new Vector3(5f,5f,1f);
        }
        */
        
        if(transform.name == "Enemy_Spider" && moveDelta.x > 0)
        {
            transform.localScale = new Vector3(-0.2f,0.2f,1f);
        }
        else
        if(transform.name == "Enemy_Spider" && moveDelta.x < 0)
        {
            transform.localScale = new Vector3(0.2f,0.2f,1f);
        }
        
        

        // reduce push force

        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);


        // check if something is in the way
        hit = Physics2D.BoxCast(transform.position, boxCollider.size/2, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));

        if(hit.collider == null)
        {
            // Add push vector if any
            moveDelta += pushDirection;
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        
        
        hit = Physics2D.BoxCast(transform.position, boxCollider.size/2, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor","Blocking"));

        if(hit.collider == null)
        {

            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
        

    }

}
