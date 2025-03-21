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
                character = new Wizard("Nico", 45);
                break;
            case CharacterType.WARRIOR:
                character = new Warrior("Rafa", 100);
                break;
        }

        GameObject pl0 = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        pl0.GetComponent<SpriteRenderer>().sprite = character.GetSprite();
        pl0.GetComponent<PlatformMovement>().speed = character.GetSpeed();

        //List<Character> personajes = new List<Character>();
        //personajes.Add(new Wizard());
        //personajes.Add(new Warrior());


        //foreach(Character personaje in personajes) 
        //{
        //    personaje.GetCurrentHealth();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            character.Attack();
        }
        else if(Input.GetKeyDown(KeyCode.F)) 
        {
            character.Defensa();
        }
    }
}
