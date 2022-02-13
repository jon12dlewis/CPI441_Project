using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Mover
{
    public Animator pickAxe;
    public Animator sword;


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
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        
        UpdateMotor(new Vector3(x,y,0));
    } 
    
}
