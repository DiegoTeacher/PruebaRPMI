using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    private float physicalForce;

    public Warrior() : base()
    {
        physicalForce = 500;
    }

    public Warrior(string name, float physicalForce) : base(name, 100, 10, Resources.Load<Sprite>("Sprites/spider"))
    {
        this.physicalForce = physicalForce;
    }

    public float GetPhysicalForce()
    {
        return physicalForce;
    }
}
