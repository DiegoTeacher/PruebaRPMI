using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCharacter : MonoBehaviour
{
    public GameObject playerPrefab;
    public CharacterType characterType;

    private Character character;

    // Start is called before the first frame update
    void Start()
    {
        switch(characterType)
        {
            case CharacterType.WIZARD:
                character = new Character("Nico", 100, 2, Resources.Load<Sprite>("Sprites/skeleton"));
                break;
            case CharacterType.WARRIOR:
                character = new Character("Rafa", 66, 7, Resources.Load<Sprite>("Sprites/spider"));
                break;
        }

        GameObject pl0 = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        pl0.GetComponent<SpriteRenderer>().sprite = character.GetSprite();

        //Debug.Log(ch0.name + " tiene " + ch0.GetCurrentHealth() + " puntos de vida actual");
        //Debug.Log(ch1.name + " tiene " + ch1.GetCurrentHealth() + " puntos de vida actual");
        //ch1.SubstractCurrentHealth(13);

        //Debug.Log(ch0.name + " tiene " + ch0.GetCurrentHealth() + " puntos de vida actual");
        //Debug.Log(ch1.name + " tiene " + ch1.GetCurrentHealth() + " puntos de vida actual");
        //ch0.SubstractCurrentHealth(9999);
        //Debug.Log(ch0.name + " tiene " + ch0.GetCurrentHealth() + " puntos de vida actual");
        //Debug.Log(ch1.name + " tiene " + ch1.GetCurrentHealth() + " puntos de vida actual");

        //Debug.Log(ch0.name + " tiene de velocidad... " + ch0.GetSpeed());
        //Debug.Log(ch1.name + " tiene de velocidad... " + ch1.GetSpeed());
        //ch0.SetSpeed(-1);
        //ch1.SetSpeed(120);

        //Debug.Log(ch0.name + " tiene de velocidad... " + ch0.GetSpeed());
        //Debug.Log(ch1.name + " tiene de velocidad... " + ch1.GetSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
