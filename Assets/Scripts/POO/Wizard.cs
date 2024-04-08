using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character
{
    private bool hasHat;

    public Wizard(string name, float damage, bool hasHat) : base(name, damage)
    {
        this.hasHat = hasHat;
    }

    public bool HasHat()
    {
        return hasHat;
    }

    public float Attack()
    {
        //if(hasHat)
        //{
        //    return damage * 2;
        //}
        //else
        //{
        //    return damage;
        //}

        return hasHat ? damage * 2 : damage;
    }
}
