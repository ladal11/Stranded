using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        ItemDatabase.CreateItemDatabase();
        // Will be moved to the map generation script
        IslandGenerator islandGenerator = GetComponent<IslandGenerator>();
        islandGenerator.GenerateIsland();
    }

}
