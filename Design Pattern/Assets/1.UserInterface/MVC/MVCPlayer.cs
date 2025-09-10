using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVCPlayer 
{
    public int Health { get; set; }
    public string Name { get; set; }

    public MVCPlayer(int health, string name)
    {
        Health = health;
        Name = name;
    }   
}
