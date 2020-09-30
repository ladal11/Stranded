using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class IslandEnvironmentDataGenerator
{
    public static void GeneratePoints(Tile[,] _tiles, int _sizeInTiles, int numSamplesBeforeRejection = 30, float radius = 2f)
    {
        //List<Vector2> points = new List<Vector2>();
        //List<Vector2> spawnPoints = new List<Vector2>();
        //int[,] grid = new int[_sizeInTiles, _sizeInTiles];

        //int islandCenterX = Mathf.FloorToInt(_sizeInTiles / 2f);
        //int islandCenterY = Mathf.FloorToInt(_sizeInTiles / 2f);

        //spawnPoints.Add(new Vector2(_tiles[islandCenterX, islandCenterY].spawnPoint.x, _tiles[islandCenterX, islandCenterY].spawnPoint.z));

        //while (spawnPoints.Count > 0)
        //{
        //    int spawnIndex = Random.Range(0, spawnPoints.Count);
        //    Vector2 spawnCenter = spawnPoints[spawnIndex];

        //    for (int i = 0; i < numSamplesBeforeRejection; i++)
        //    {
        //        float angle = Random.value * Mathf.PI * 2;
        //        Vector2 dir = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
        //        Vector2 candidate = spawnCenter + dir * Random.Range(radius, 2 * radius);
        //        if (isValid(candidate))
        //        {
        //            points.Add(candidate);
        //            spawnPoints.Add(candidate);

        //        }
        //    }

        //}

    }
}
