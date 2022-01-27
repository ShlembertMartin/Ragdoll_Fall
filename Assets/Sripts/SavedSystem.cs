using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavedSystem
{
    public static void SaveCamera (CameraController camera)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/camera.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        CameraData data = new CameraData(camera);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static CameraData LoadCamera()
    {
        string path = Application.persistentDataPath + "/camera.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CameraData data = formatter.Deserialize(stream) as CameraData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file is not found in" + path);
            return null;
        }
    }
}
