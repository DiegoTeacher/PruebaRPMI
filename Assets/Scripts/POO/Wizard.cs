using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character
{
    private bool hasHat;
    private float maxTime = 4, currentTime = 0;

    public Wizard(string name, float damage, bool hasHat) : base(name, damage, Resources.Load<Sprite>("Sprites/wizard"))
    {
        this.hasHat = hasHat;
        SetJumpForce(2.5f);
        color = Color.red;
    }

    public bool HasHat()
    {
        return hasHat;
    }

    public override float Attack()
    {
        //if(hasHat)
        //{
        //    return damage * 2;
        //}
        //else
        //{
        //    return damage;
        //}
        Debug.Log("Wizard ataca");
        return hasHat ? damage * 2 : damage;
    }

    public override void Skill(Rigidbody2D rb)
    {
        rb.gravityScale = 0f;
        rb.velocity = Vector3.zero;
    }

    public override void Update(Rigidbody2D rb)
    {
        if(rb.gravityScale == 0)
            currentTime += Time.deltaTime;

        if(currentTime >= maxTime)
        {
            rb.gravityScale = 1;
            currentTime = 0;
        }
    }
}
