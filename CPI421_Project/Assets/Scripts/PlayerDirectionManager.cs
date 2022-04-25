using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionManager : MonoBehaviour
{
    public static int direction;
    public static bool moving;
    public enum LRUD {left, right, up, down};

    Vector2 playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition = transform.position;

        // tracks current direction
        if(mousePos.x > playerPosition.x + 1.5)
        {
            direction = (int)LRUD.right;
        }
        else
        if(mousePos.x < playerPosition.x - 1.5)
        {
            direction = (int)LRUD.left;
        }
        else
        if(mousePos.y > playerPosition.y + 1.5)
        {
            direction = (int)LRUD.up;
        }
        else
        if(mousePos.y < playerPosition.y - 1.5)
        {
            direction = (int)LRUD.down;

        }

        // tracks whether player is moving or not
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            moving = true;
        }
        else {
            moving = false;
        }
    }
}
