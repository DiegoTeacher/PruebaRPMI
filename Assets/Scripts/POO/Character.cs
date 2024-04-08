using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    protected float damage;

    public Character(string name, float damage)
    {
        this.name = name;
        this.damage = damage;
    }

    public float GetDamage()
    {
        return damage;
    }
}
