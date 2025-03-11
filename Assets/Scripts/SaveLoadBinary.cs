using System;
using System.IO;
using UnityEngine;

public class SaveLoadBinary : MonoBehaviour
{
    public string fileName = "test.bin";

    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.persistentDataPath + '\\' + fileName;
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    // Update is called once per frame
    //void LateUpdate()
    //{
    //    if (Input.GetKeyDown(KeyCode.G))
    //    {
    //        Save();
    //    }
    //    else if (Input.GetKeyDown(KeyCode.L))
    //    {
    //        Load();
    //    }
    //}

    void Save() 
    {
        BinaryWriter binaryWriter = new BinaryWriter(new FileStream(fileName, FileMode.Create));
        binaryWriter.Flush();
        binaryWriter.Write(transform.position.x);
        binaryWriter.Write(transform.position.y);
        binaryWriter.Write(transform.position.z);
        binaryWriter.Flush();
        binaryWriter.Close();
    }

    void Load()
    {
        if (!File.Exists(fileName))
        {
            return;
        }
        
        BinaryReader binaryReader = new BinaryReader(new FileStream(fileName, FileMode.Open));
        try
        {
            float x = binaryReader.ReadSingle();
            float y = binaryReader.ReadSingle();
            float z = binaryReader.ReadSingle();
            transform.position = new Vector3(x, y, z);
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
        binaryReader.Close();

    }
}












//BinaryReader br = new BinaryReader(new FileStream(Application.persistentDataPath + '\\' + "mdata", FileMode.Open));
//float x = br.ReadSingle();
//float y = br.ReadSingle();
//float z = br.ReadSingle();
//br.Close();
//transform.position = new Vector3(x, y, z);





//BinaryWriter bw = new BinaryWriter(new FileStream(Application.persistentDataPath + '\\' + "mdata", FileMode.Create));
//bw.Write(transform.position.x);
//bw.Write(transform.position.y);
//bw.Write(transform.position.z);
//bw.Close();