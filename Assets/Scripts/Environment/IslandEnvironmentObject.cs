using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;


// rocks, trees, grass, flowers

public enum EnvironmentObjName
{
    PalmTree01,
}

public enum EnvironmentObjType
{
    Rock,
    Tree,
    Ore
}


public struct EnvironmentObjData
{
    public EnvironmentObjType environmentObjType;
    public string prefabPath;
    public int size;
    public float minAltitude;
    public float maxAltitude;

    public EnvironmentObjData(EnvironmentObjType _environmentObjType, string _prefabPath, int _size, float _minAltitude, float _maxAltitude)
    {
        environmentObjType = _environmentObjType;
        prefabPath = _prefabPath;
        size = _size;
        minAltitude = _minAltitude;
        maxAltitude = _maxAltitude;
    }
}

public class EnvironmentObjDatabase
{
    public static Dictionary<EnvironmentObjName, EnvironmentObjData> environmentObjects = new Dictionary<EnvironmentObjName, EnvironmentObjData>();

    public static void CreateEnvironmentObjDatabase()
    {
        // Debug Tree
        environmentObjects.Add(EnvironmentObjName.PalmTree01, new EnvironmentObjData(EnvironmentObjType.Tree, "GameObjects/Trees/palmTree1", 3, 3.0f, 50.0f));
    }
}



public class IslandEnvironmentObject
{
    public EnvironmentObjName environmentObjName;
    public IslandEnvironmentObject(EnvironmentObjName _environmentObjName)
    {
        environmentObjName = _environmentObjName;
    }
}
