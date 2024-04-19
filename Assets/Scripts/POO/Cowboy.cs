using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : Character
{

    public Cowboy(string name, float damage) : base(name, damage, Resources.Load<Sprite>("Sprites/cowboy")) // construimos padre
    {
        // construimos hijo
        SetJumpForce(5);
        color = Color.yellow;
    }

    public override float Attack()
    {
        Debug.Log("Cowboy ataca");
        return Random.Range(damage, damage * 2);
    }

    public override float Heal()
    {
        Debug.Log("cowboy se cura");
        health += 10;
        base.Heal();
        return 10;
    }

    public override void Skill(Rigidbody2D rb)
    {
        throw new System.NotImplementedException();
    }
}
