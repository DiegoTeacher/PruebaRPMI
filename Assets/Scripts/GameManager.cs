using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameManagerVariables { TIME, POINTS };

    private float time;
    private int points;

    public Human capitan;

    private void Awake()
    {

        // SINGLETON
        if (!instance) // si instance no tiene informacion
        {
            instance = this; // instance se asigna a este objeto
            DontDestroyOnLoad(gameObject); // se indica que este obj no se destruya con la carga de escenas
        }
        else // si instance tiene info
        {
            Destroy(gameObject); // se destruye el gameObject, para que no haya dos o mas gms en el juego
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    // getter
    public float GetTime()
    {
        return time;
    }

    public void ResetTime()
    {
        time = 0;
    }

    // getter
    public int GetPoints()
    {
        return points;
    }

    // setter
    public void SetPoints(int value)
    {
        points = value;
    }

    // callback ---> funcion que se va a llamar en el onclick() de los botones
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        // oye, audiomanager, limpia todos los sonidos que estan sonando
        AudioManager.instance.ClearAudios();
    }

    public void ExitGame()
    {
        Debug.Log("Exit!!");
        Application.Quit();
    }

    public void SelectCharacter()
    {
        TMP_Dropdown dropdown = FindObjectOfType<TMP_Dropdown>();
        if(dropdown.value == 0)
        {
            capitan = new CapitanAmerica("Steve", 100, null);
        }
        else if(dropdown.value == 1)
        {
            capitan = new CapitanSalami("Amador", 79, null);
        }
    }
}
