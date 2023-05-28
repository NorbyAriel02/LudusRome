using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character System/Character/Database")]
public class GladiatorDataBaseObject : ScriptableObject
{
    public GladiatorObjectV2[] GladiatorObjects;
    
    [ContextMenu("Load Gladiators")]
    private void Load()
    {
        string[] guids = AssetDatabase.FindAssets("t:GladiatorObjectV2");
        GladiatorObjects = new GladiatorObjectV2[guids.Length];
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GladiatorObjectV2 obj = AssetDatabase.LoadAssetAtPath<GladiatorObjectV2>(path);
            GladiatorObjects[obj.indexDB] = obj;
        }
    }
}
