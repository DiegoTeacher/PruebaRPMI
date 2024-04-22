using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Human : Character, ISoldier, IHero
{
    protected Human(string name, float damage, Sprite sprite) : base(name, damage, sprite)
    {
    }

    public abstract Color CompleteQuest();
    public abstract Color Disparar();
    public abstract Color MostrarEventoCanonico();
}
