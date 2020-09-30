using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    public IslandData islandData;

    public Mesh CreateMeshFromData()
    {
        // returns a mesh for now but will be unnecessary once the GenerateIsland is fully implemented.
        return islandData.islandMeshData.CreateMesh();
    }
}
