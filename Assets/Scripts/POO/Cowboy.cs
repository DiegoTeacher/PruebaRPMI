using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : Character
{

    public Cowboy(string name, float damage) : base(name, damage) // construimos padre
    {
        // construimos hijo
    }

    public float Attack()
    {
        return Random.Range(damage, damage * 2);
    }
}
