using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameManagerVariables { TIME, POINTS };
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<string> hours;

    // Start is called before the first frame update
    void Awake()
    {
        if(!instance)
        {
            instance = this;
            hours = new List<string>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SetHours(List<string> value)
    {
        hours = value;
    }

    public List<string> GetHours()
    {
        return hours;
    }
}
