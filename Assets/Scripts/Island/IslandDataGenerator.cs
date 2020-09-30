using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IslandDataGenerator
{
    public static IslandData GenerateIslandData(int sizeInTiles, float islandHeightDampener, float islandHeight, AnimationCurve heightCurve, float scale, int seed, int octaves, float persistance, float lacunarity, Vector2 offset, float noiseMultiplier, float islandBenchmarkInfluence)
    {
        IslandMeshData newIslandMeshData = IslandMeshDataGenerator.GenerateIslandMeshData(sizeInTiles, islandHeightDampener, islandHeight, heightCurve, scale, seed, octaves, persistance, lacunarity, offset, noiseMultiplier, islandBenchmarkInfluence);
        Tile[,] tiles = TileManager.GenerateTilesFromMesh(newIslandMeshData);
        //IslandEnvironment islandEnvironment = new IslandEnvironment(tiles, sizeInTiles);
        //islandEnvironment.GenerateTreeData();
        return new IslandData(new Vector2(0f, 0f), sizeInTiles, newIslandMeshData, tiles);
    }
}
