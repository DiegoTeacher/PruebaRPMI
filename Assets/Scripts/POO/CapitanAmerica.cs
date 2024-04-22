using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitanAmerica : Human
{
    public CapitanAmerica(string name, float damage, Sprite sprite) : base(name, damage, sprite)
    {
    }

    public override float Attack()
    {
        throw new System.NotImplementedException();
    }

    public override Color CompleteQuest()
    {
        return Color.white;
    }

    public override Color Disparar()
    {
        return Color.blue;
    }

    public override Color MostrarEventoCanonico()
    {
        return Color.red;
    }

    public override void Skill(Rigidbody2D rb)
    {
        throw new System.NotImplementedException();
    }
}
