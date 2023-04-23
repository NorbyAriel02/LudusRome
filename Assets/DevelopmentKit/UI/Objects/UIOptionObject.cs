using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "New UI Options", menuName = "UI Options/New UI Options")]
public class UIOptionObject : ScriptableObject
{
    public string savePath;
    public UIOptions options;

    /* Cargamos los items desde el archivo a 
     * memorio en el objeto inventario */
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            options = (UIOptions)formatter.Deserialize(stream);
            stream.Close();
        }
        else
        {
            options = new UIOptions();
        }        
    }
    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, options);
        stream.Close();
    }
}
