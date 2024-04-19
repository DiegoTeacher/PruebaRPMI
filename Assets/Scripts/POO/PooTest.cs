using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //RPMI.Vector3 vector3_2 = new RPMI.Vector3("Vector Yanes", 0, 10, 9);
        //print(vector3_2.GetName() + " " + vector3_2.x);
        //print("El vector " + vector3_2.GetName() + " mide " + vector3_2.Modulo()); // 13.45
        //vector3_2.Add(5, 10, -45);
        //vector3_2.Add(new RPMI.Vector3("a", 1, 1, 1)); // 6, 21, -35
        //vector3_2.Mul(10); // 60, 210, -350
        //print("El vector " + vector3_2.GetName() + " mide " + vector3_2.Modulo()); // 412.553

        
        //Wizard mago0 = new Wizard("Alfonso", 222, true);
        //Wizard mago1 = new Wizard("Carlos", 33, false);
        Cowboy vaquero1 = new Cowboy("Anyi", 49);
        vaquero1.Heal();

        List<Character> characters = new List<Character>();
        characters.Add(vaquero1);
        //characters.Add(mago0);
        //characters.Add(mago1);
        // Mason isma = new Mason();
        // characters.Add(isma); // no se puede hacer, isma (mason) != Character
        //foreach (Character character in characters)
        //{
        //    print(character.name + " ataca con " + character.Attack() + " puntos de daño");
        //}
            //print(mago0.name + " tiene " + mago0.GetDamage() + " puntos de daño");
            //print(vaquero1.name + " tiene " + vaquero1.GetDamage() + " puntos de daño");
            //print(mago1.name + " tiene " + mago1.GetDamage() + " puntos de daño");
    }
}
