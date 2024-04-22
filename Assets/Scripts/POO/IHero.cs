using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHero
{
    void Save()
    {
        Debug.Log("Salvando");
    }

    Color MostrarEventoCanonico();
}
