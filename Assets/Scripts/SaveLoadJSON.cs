using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
struct PlayerData
{
    public Vector3 position;
    public int puntuation;
    public List<string> hours;
}

public class SaveLoadJSON : MonoBehaviour
{
    public string fileName = "test.json";

    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.persistentDataPath + '\\' + fileName;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Save();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    private void Save()
    {
        StreamWriter streamWriter = new StreamWriter(fileName);

        PlayerData playerData = new PlayerData(); // instancio obj que vamos a guardar
        playerData.position = transform.position; // rellenamos de info
        // playerData.puntuation = GM.instance.GetScore();
        List<string> hoursAux = GameManager.instance.GetHours();
        hoursAux.Add(DateTime.Now.ToString("HH:mm:ss"));
        playerData.hours = hoursAux;

        string json = JsonUtility.ToJson(playerData);
        streamWriter.Write(json);


        streamWriter.Close();
    }

    private void Load() 
    {
        if (File.Exists(fileName)) 
        {
            StreamReader streamReader = new StreamReader(fileName);

            string json = streamReader.ReadToEnd();
            streamReader.Close();

            try
            {
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
                transform.position = playerData.position;
                // GM.instance.SetScore(playerData.puntuation);
                GameManager.instance.SetHours(playerData.hours);
            }
            catch(System.Exception e)
            {
                // sacar al topo de AC
                Debug.Log(e.Message);
            }
        }
    }
}
