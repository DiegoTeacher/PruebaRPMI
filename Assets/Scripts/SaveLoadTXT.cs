using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadTXT : MonoBehaviour
{
    public string fileName = "test.txt";
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Save();
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
           Load();
        }
    }

    private void Save()
    {
        // guardar
        StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + '\\' + fileName);
        streamWriter.WriteLine("Archivo de guardado");
        streamWriter.WriteLine(UnityEngine.Random.Range(0, 100));
        streamWriter.WriteLine(transform.position.x);
        streamWriter.WriteLine(transform.position.y);
        streamWriter.WriteLine(transform.position.z);
        List<string> hoursAux = GameManager.instance.GetHours();
        hoursAux.Add(DateTime.Now.ToString("HH:mm:ss"));
        foreach(string hour in hoursAux)
        {
            streamWriter.WriteLine(hour);
        }


        streamWriter.Close(); // importante!!!
    }

    private void Load()
    {
        // cargar informacion
        if (File.Exists(Application.persistentDataPath + '\\' + fileName))
        {
            try
            {
                StreamReader streamReader = new StreamReader(Application.persistentDataPath + '\\' + fileName);
                streamReader.ReadLine(); // la primera linea no es importante,
                                         // movemos el cursor del archivo a la siguiente linea
                streamReader.ReadLine();
                float x = float.Parse(streamReader.ReadLine());
                float y = float.Parse(streamReader.ReadLine());
                float z = float.Parse(streamReader.ReadLine());

                List<string> hoursAux = new List<string>();

                // como las horas es lo ultimo que se guarda...
                while(!streamReader.EndOfStream) 
                {
                    hoursAux.Add(streamReader.ReadLine());
                }

                GameManager.instance.SetHours(hoursAux);

                streamReader.Close();

                transform.position = new Vector3(x, y, z); // establecemos la posicion del GO
            }
            catch (System.Exception e) // como no guardamos info en ningun servidor,
                                       // guardamos en LOCAL, no tenemos control
                                       // sobre los archivos del usuario. Nos aseguramos de
                                       // que si algo va mal, este todo controlado
            {
                // sacar al topo de AC
                Debug.Log(e.Message);
            }
        }
    }
}
