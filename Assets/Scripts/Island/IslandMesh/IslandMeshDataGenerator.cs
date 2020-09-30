using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMeshDataGenerator
{

    public static IslandMeshData GenerateIslandMeshData(int sizeInTiles, float islandHeightDampener, float islandHeight, AnimationCurve heightCurve, float scale, int seed, int octaves, float persistance, float lacunarity, Vector2 offset, float noiseMultiplier, float islandBenchmarkInfluence)
    {
        int size = sizeInTiles + 1;
        IslandMeshData islandMeshData = new IslandMeshData(size);
        Vector2 islandCenter = new Vector2((size - 1) / 2f, (size - 1) / 2f);

        float maxDistanceToCenter= Mathf.Sqrt(Mathf.Pow(size / 2, 2f) + Mathf.Pow(size / 2, 2f));


        int vertexIndex = 0;
        float[,] heightMap = Noise.GenerateHeightMap(size, scale, seed, octaves, persistance, lacunarity, offset);

        float topLeftX = (size - 1) / -2.0f;
        float topLeftZ = (size - 1) / 2.0f;

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float islandX = topLeftX + x;
                float islandY = topLeftZ - y;


                float distanceToCenter = Mathf.Sqrt(Mathf.Pow(islandX, 2f) + Mathf.Pow(islandY, 2f));
                float heightCurveValue = heightCurve.Evaluate(distanceToCenter / maxDistanceToCenter);
                float vertexHeight = heightCurveValue * islandBenchmarkInfluence + heightMap[x, y] * noiseMultiplier + islandHeight;
                    
                islandMeshData.vertices[vertexIndex] = new Vector3(islandX, vertexHeight, islandY);
                islandMeshData.uvs[vertexIndex] = new Vector2(x / (float)size, y / (float)size);

                if (x < size - 1 && y < size - 1)
                {
                    int topLeftIndex = vertexIndex;
                    int topRightIndex = vertexIndex + 1;
                    int bottomLeftIndex = vertexIndex + size;
                    int bottomRightIndex = vertexIndex + size + 1;

                    islandMeshData.AddTriangle(topLeftIndex, bottomRightIndex, bottomLeftIndex);
                    islandMeshData.AddTriangle(bottomRightIndex, topLeftIndex, topRightIndex);
                }

                vertexIndex++;
                
            }
        }

        return islandMeshData;
    }
}
