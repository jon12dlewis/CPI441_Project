using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public float targetTime = 10.0f;

    public bool regen = false;

    public player Player;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<player>();
        health = Player.hitPoint;
        maxHealth = Player.maxHitpoint;
    }

    public void SetHealth()
    {
        Player = GameObject.Find("Player").GetComponent<player>();
        health = Player.hitPoint;
        maxHealth = Player.maxHitpoint;
        numOfHearts = Player.maxHitpoint;
    }

    void Update()
    {
        health = Player.hitPoint;

        targetTime -= Time.deltaTime;
 
        if(regen == true)
        {
            if(targetTime <= 0.0f && health != Player.maxHitpoint)
            {
                Player.hitPoint += 1;
                targetTime = 10.0f;
            }
        }

        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

    }
}
