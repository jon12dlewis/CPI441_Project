using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToBase : Collidable
{

    private Animator door;
    private float coolDown = 5f;
    private float lastShot;
    private bool canLeave = true;
    public bool exit = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        door = GameObject.FindGameObjectWithTag("door").GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

                if(Time.time - lastShot > coolDown)
                {
                    lastShot = Time.time;
                    canLeave = true;
                }  

    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if(coll.name == "Player")
            {

                if(canLeave)
                {
                    if(exit)
                    {
                        Scene scene = SceneManager.GetActiveScene();
                        if((scene.name == "Level 1") && (GameManager.instance.levelsCompleted == 1))
                        {
                            GameManager.instance.nextLevel();
                        }
                        else
                        if((scene.name == "Level 2") && (GameManager.instance.levelsCompleted == 2))
                        {
                            GameManager.instance.nextLevel();
                        }
                    }
                    canLeave = false;
                    door.SetTrigger("active");
                    lastShot = Time.time;
                }   

            }

        }
    }

}
