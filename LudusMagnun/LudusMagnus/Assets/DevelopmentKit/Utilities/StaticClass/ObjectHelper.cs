using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public static class ObjectHelper 
{
    public static List<GameObject> GetPull(GameObject prefab, int count, Transform parent)
    {
        List<GameObject> list = new List<GameObject>();
        for(int i = 0; i < count;i++)
        {
            GameObject go = UnityEngine.Transform.Instantiate(prefab, parent);
            go.SetActive(false);
            list.Add(go);
        }
        return list;
    }
    public static GameObject GetParentWithComponent<T>(GameObject go) where T : Component
    {
        if(go.GetComponent<T>() != null)
        {
            return go;
        }
        GameObject father = go.transform.parent.gameObject;
        if(father != null)
            return GetParentWithComponent<T>(father);

        return null;
    }
    public static GameObject CreateImageForUI(string name = "New Image", Sprite sprite = null, bool rayCaster = true, Transform father = null)
    {
        GameObject img = new GameObject();
        img.name = name;
        img.AddComponent<RectTransform>();
        img.AddComponent<CanvasRenderer>();
        Image imgComponet = img.AddComponent<Image>();
        imgComponet.sprite = sprite;
        imgComponet.raycastTarget = rayCaster;
        img.transform.SetParent(father);
        return img;
    }
    /*El objeto puede ser cualquier objeto serializable o una lista de esos objetos*/
    public static T GetObject<T>(string path) where T : class
    {
        T obj = null;
        if (File.Exists(string.Concat(Application.persistentDataPath, path)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, path), FileMode.Open, FileAccess.Read);
            obj = (T)formatter.Deserialize(stream);
            stream.Close();
        }

        return obj;
    }
    /*El objeto puede ser cualquier objeto serializable o una lista de esos objetos*/
    public static void SaveObject<T>(string path, T list) where T: class
    {
        using (Stream stream = new FileStream(string.Concat(Application.persistentDataPath, path), FileMode.Create, FileAccess.Write))
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, list);
            stream.Close();
        }
    }
}
