using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMeshData
{
    const float islandHeightChunk = 0.5f;
    const float islandMaxDeltaHeight = 1.0f;
    private Mesh mesh;

    public int size;
    public int sizeInTiles;
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;
    
    public Tile[] tiles;

    private int triangleIndex = 0;

    public IslandMeshData(int _size)
    {
        // Size in Vertex! Would be one nice cleanup to clarify this somewhere...
        size = _size;
        sizeInTiles = size - 1;
        vertices = new Vector3[size * size];
        triangles = new int[sizeInTiles * sizeInTiles * 6];
        uvs = new Vector2[size * size];
    }

    public void AddTriangle(int a, int b, int c)
    {
        triangles[triangleIndex] = a;
        triangles[triangleIndex + 1] = b;
        triangles[triangleIndex + 2] = c;
        triangleIndex += 3;
    }


    public Mesh CreateMesh()
    {
        mesh = new Mesh();
        // We must add the vertices before the triangles to the mesh because a set_triangle method is called on triangles assignation. It fails if vertices is empty at that point.
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;

        // Check how this actually behaves and if I can clean this up. Calling each of them as this does not seem to have a cost on performance for now.
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        return mesh;
    }
}
