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

    public override void Attack()
    {
        base.Attack();
        RaycastHit2D[] cols = Physics2D.CircleCastAll(Vector2.zero, 5, Vector2.up);

        foreach (RaycastHit2D item in cols)
        {
            Rigidbody2D rigidbody2D = item.collider.gameObject.GetComponent<Rigidbody2D>();
            if (rigidbody2D)
            {
                rigidbody2D.AddForce(new Vector2(Random.Range(-500, 500), Random.Range(-500, 500)));
            }
        }
    }

    public override void Defensa()
    {
        Debug.Log("Warrior se defiende");
    }
}
