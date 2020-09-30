using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandData
{
    public IslandMeshData islandMeshData;
    //IslandEnvironmentData islandEnvironmentData;
    public Tile[,] tiles;
    // Variables to add: Spawns, Objects(Builds, Environment, Placeable)
    public Vector2 location;
    public int sizeInTiles;

    public IslandData(Vector2 _location, int _sizeInTiles, IslandMeshData _islandMeshData, Tile[,] _tiles)
    {
        location = _location;
        sizeInTiles = _sizeInTiles;
        islandMeshData = _islandMeshData;
        tiles = _tiles;
        //islandEnvironmentData = _islandEnvironmentData;
    }

    public Tile GetTileByTriangleIndex(int _triangleindex)
    {
        int index = _triangleindex / 2;
        int y = Mathf.FloorToInt(index / sizeInTiles);
        int x = index % sizeInTiles;

        return tiles[x, y];
    }

}


