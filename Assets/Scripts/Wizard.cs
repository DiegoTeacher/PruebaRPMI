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

   
}
