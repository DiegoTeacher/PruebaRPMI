using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public enum CharacterType { WIZARD, WARRIOR };

public abstract class Character
{
    public string name;
    private float maxHealth, currentHealth, speed;
    private Sprite sprite;

    public Character() // constructor por defecto / sin argumentos
    {
        this.maxHealth = 100;
        this.currentHealth = this.maxHealth;
        this.speed = 5;
        name = "DEFAULT_NAME";
        sprite = null;
    }

    public Character(string name, float maxHealth, float speed, Sprite sprite)
    {
        this.name = name;
        this.maxHealth = maxHealth;
        this.speed = speed;
        currentHealth = this.maxHealth;
        this.sprite = sprite;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetMaxHealth() 
    {
        return maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetSpeed(float value)
    {
        if (value >= 0) 
        {
            this.speed = value;
        }
    }

    public virtual void Attack() 
    {
        Debug.Log("Character attacks!");
    }

    public abstract void Defensa();

    public void SubstractCurrentHealth(float value)
    {
        currentHealth -= value;

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public Sprite GetSprite()
    {
        return sprite;
    }
}
