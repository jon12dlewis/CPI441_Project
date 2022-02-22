using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal_node : Fighter
{
    public Sprite Crystal_0;
    public Sprite Crystal_1;
    public Sprite Crystal_2;
    public Sprite Crystal_3;

    protected virtual void Update()
    {
        switch (hitPoint)
        {
            case 8:
                GetComponent<SpriteRenderer>().sprite = Crystal_0;
              break;
            case 6:
                GetComponent<SpriteRenderer>().sprite = Crystal_1;
                break;
            case 4:
                GetComponent<SpriteRenderer>().sprite = Crystal_2;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = Crystal_3;
                break;
            case 0:
                Death();
                break;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.GiveBlueCrystal(69);
        GameManager.instance.ShowText("Blue Crystal Obtained ", 40, Color.blue, transform.position, Vector3.up * 40, 1.0f);
    }
}
