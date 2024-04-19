using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character
{
    public string name;
    public float health;
    protected float damage;
    protected float jumpForce;
    protected Sprite _sprite;
    public Color color;

    public Character(string name, float damage, Sprite sprite)
    {
        this.name = name;
        this.damage = damage;
        _sprite = sprite;
    }

    public Sprite GetSprite() { return _sprite; }
    public float GetJumpForce() { return jumpForce; }

    protected void SetJumpForce(float jF)
    {
        if(jF > 0)
            this.jumpForce = jF;
    }

    public float GetDamage()
    {
        return damage;
    }

    public abstract float Attack();
    public abstract void Skill(Rigidbody2D rb);

    public virtual void Update(Rigidbody2D rb)
    {

    }

    public virtual float Heal()
    {
        Debug.Log("Character se cura");
        //if(health > 100)
        //{
        //    return 100;
        //}
        //else if(health < 0)
        //{
        //    return 0;
        //}
        //else
        //{
        //    return health;
        //}
        health = Mathf.Clamp(health, 0, 100);
        return health;
    }
}
