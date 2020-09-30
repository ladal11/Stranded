using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGenerator : MonoBehaviour
{
    public bool editorAutoUpdate;


    public int islandSize;
    public float islandHeightDampener;
    public float islandHeight;
    public AnimationCurve heightCurve;
    [Range(0.1f, 500f)]
    public float scale;
    public int seed;
    public float noiseMultiplier;

    [Range(1,5)]
    public int octaves;
    [Range(0,1)]
    public float persistance;
    [Range(1,10)]
    public float lacunarity;
    public Vector2 offset;
    public float islandBenchmarkInfluence;



    
    public void GenerateIsland()
    {
        /* Must be implemented to take only islandData! This will be what is stored to destroy and create island depending on player position
        Debug Implementation -> Most responsabilities of this method will be moved */

        //EnvironmentObjDatabase.CreateEnvironmentObjDatabase();

        // Create Island Game Object and its components
        Island island;
        GameObject islandGO;
        MeshFilter meshFilter;
        MeshRenderer meshRenderer;
        MeshCollider meshCollider;
        islandGO = new GameObject("Island");
        islandGO.tag = "Island";
        islandGO.layer = LayerMask.NameToLayer("Ground");
        meshFilter = islandGO.AddComponent<MeshFilter>();
        meshRenderer = islandGO.AddComponent<MeshRenderer>();
        meshCollider = islandGO.AddComponent<MeshCollider>();
        island = islandGO.AddComponent<Island>();
        
        // Generate Island Data and store it in the Game Object
        IslandData islandData = IslandDataGenerator.GenerateIslandData(islandSize, islandHeightDampener, islandHeight, heightCurve, scale, seed, octaves, persistance, lacunarity, offset, noiseMultiplier, islandBenchmarkInfluence);
        island.islandData = islandData;

        // Create the island Mesh from the data
        Mesh newIslandMesh = island.CreateMeshFromData();

        // Apply new Mesh to the Island Game Object
        meshFilter.mesh = newIslandMesh;
        meshCollider.sharedMesh = newIslandMesh;

        // Apply a debug material with a custom shader until I have something else
        Material debugIslandMat = Resources.Load("Materials/IslandGround") as Material;
        meshRenderer.material = debugIslandMat;

    }

}
