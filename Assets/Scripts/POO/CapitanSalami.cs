using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapitanSalami : Human
{
    public CapitanSalami(string name, float damage, Sprite sprite) : base(name, damage, sprite)
    {
    }

    public override float Attack()
    {
        throw new System.NotImplementedException();
    }

    public override Color CompleteQuest()
    {
        return Color.yellow;
    }

    public override Color Disparar()
    {
        return Color.red;
    }

    public override Color MostrarEventoCanonico()
    {
        return Color.red;
    }

    public override void Skill(Rigidbody2D rb)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
