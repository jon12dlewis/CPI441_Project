using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public string name;
    public int gold;

    public User(string name, int gold)
    {
        this.name = name;
        this.gold = gold;
    }
}
