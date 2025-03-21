using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// QUE EL MAGO LANCE FUEGO Y EL GUERRERO PEGUE A MELEE
public class Wizard : Character
{
    private float mana;

    public Wizard() : base()
    {
        mana = 100;
    }

    public Wizard(string name, float mana) : base(name, 50, 5, Resources.Load<Sprite>("Sprites/skeleton"))
    {
        this.mana = mana;
    }

    public float GetMana()
    {
        return mana;
    }

    public override void Attack()
    {
        base.Attack();
        GameObject.Instantiate(Resources.Load<GameObject>("fireball"));
    }

    public override void Defensa()
    {
        Debug.Log("mAGO DEFIENDE");
    }

}
