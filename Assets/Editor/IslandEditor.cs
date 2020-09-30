using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(IslandGenerator))]
public class IslandEditor : Editor
{

    public override void OnInspectorGUI()
    {
        
        IslandGenerator islandGenerator = (IslandGenerator)target;

        if (DrawDefaultInspector())
        {
            if (islandGenerator.editorAutoUpdate)
            {
                GenerateIslandInEditor(islandGenerator);
            }
        }

        if (GUILayout.Button("Generate"))
        {
            GenerateIslandInEditor(islandGenerator);
        }
    }

    private void GenerateIslandInEditor(IslandGenerator islandGenerator)
    {
        Island[] islands = FindObjectsOfType(typeof(Island)) as Island[];

        foreach (Island island in islands)
        {
            DestroyImmediate(island.gameObject);
        }
        islandGenerator.GenerateIsland();
    }
}