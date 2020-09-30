using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TileManager
{
    public static Tile[,] GenerateTilesFromMesh(IslandMeshData _islandMeshData)
    {
        int sizeInTiles = _islandMeshData.sizeInTiles;
        Vector3[] vertices = _islandMeshData.vertices;

        Tile[,] tiles = new Tile[sizeInTiles, sizeInTiles];

        for (int y = 0;  y < sizeInTiles; y++)
        {
            for (int x = 0; x < sizeInTiles; x++)
            {
                int topLeftIndex = y * (sizeInTiles + 1) + x;
                int topRightIndex = y * (sizeInTiles + 1) + x + 1;
                int bottomLeftIndex = (y + 1) * (sizeInTiles + 1) + x;
                int bottomRightIndex = (y + 1) * (sizeInTiles + 1) + x + 1;

                Tile tile = new Tile(new Vector3[] { vertices[topLeftIndex], vertices[topRightIndex], vertices[bottomLeftIndex], vertices[bottomRightIndex] });
                tiles[x, y] = tile;
            }
        }

        return tiles;
    }
    
}
