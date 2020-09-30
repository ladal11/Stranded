using UnityEngine;

public class Tile
{
    public bool blocked;
    public IslandEnvironmentObject islandEnvironmentObject;

    public Vector3[] vertices = new Vector3[4];


    Vector3 topLeftVertex
    {
        get
        {
            return vertices[0];
        }
    }
    Vector3 topRightVertex
    {
        get
        {
            return vertices[1];
        }
    }
    Vector3 bottomLeftVertex
    {
        get
        {
            return vertices[2];
        }
    }
    Vector3 bottomRightVertex
    {
        get
        {
            return vertices[3];
        }
    }

    public float highestVertexHeight;
    public float averageVertexHeight;
    public float lowestVertexHeight;
    public Vector3 tilePosition;
    public Vector3 spawnPoint;


    public Tile(Vector3[] _vertices)
    {
        vertices = _vertices;
        ComputeTileAttributes();
    }

    private void ComputeTileAttributes()
    {
        highestVertexHeight = Mathf.Max(new float[] { topLeftVertex.y, topRightVertex.y, bottomLeftVertex.y, bottomRightVertex.y });
        averageVertexHeight = (topLeftVertex.y + topRightVertex.y + bottomLeftVertex.y + bottomRightVertex.y) / 4f;
        lowestVertexHeight = Mathf.Min(new float[] { topLeftVertex.y, topRightVertex.y, bottomLeftVertex.y, bottomRightVertex.y });

        tilePosition = new Vector3((topRightVertex.x + topLeftVertex.x) / 2f, highestVertexHeight, (bottomLeftVertex.z + topLeftVertex.z) / 2f);
        spawnPoint = new Vector3((topRightVertex.x + topLeftVertex.x) / 2f, lowestVertexHeight, (bottomLeftVertex.z + topLeftVertex.z) / 2f);
    }

    public void AddTree(IslandEnvironmentObject _tree)
    {
        if (!blocked)
        {
            islandEnvironmentObject = _tree;
            blocked = true;
        }
    }
}
