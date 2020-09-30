using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terraform : MonoBehaviour
{
    private Player player;
    public GameObject highlightPrefab;
    private GameObject highlightGO;
    private Island currentSelectedIsland;
    private int currentSelectedTriangle;
    private Tile currentSelectedTile;
    private RaycastHit currentLookHit;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        Debug.Log("Terraforming...");
        highlightGO = (GameObject)Instantiate(highlightPrefab, Vector3.zero, Quaternion.identity);
        highlightGO.SetActive(false);
    }

    private void OnDisable()
    {
        Destroy(highlightGO);
    }

    private void Update()
    {
        UpdateCurrentLookHit();
        UpdateCurrentTriangle();
        UpdateCurrentTile();

        if (Input.GetButtonDown("Fire1"))
        {
        }

        else if (Input.GetButtonDown("Fire2"))
        {
        }

    }



    private void UpdateCurrentTriangle()
    {
        currentSelectedTriangle = GetLookTriangle();
    }

    private int GetLookTriangle()
    {
        /*
         Select a triangle if it is part of an Island. Update Island at the same time -> TO DO:  Separate functionality
         */

        if (currentLookHit.transform == null || !currentLookHit.transform.gameObject.CompareTag("Island"))
        {
            return -1;
        }

        Island selectedIsland = currentLookHit.transform.gameObject.GetComponent<Island>() as Island;

        if (currentSelectedIsland != selectedIsland)
        {
            currentSelectedIsland = selectedIsland;
        }
        return currentLookHit.triangleIndex;
    }

    private void UpdateCurrentTile()
    {

        if (currentSelectedTriangle >= 0)
        {
            Tile selectedTile = currentSelectedIsland.islandData.GetTileByTriangleIndex(currentSelectedTriangle);
            if (currentSelectedTile != selectedTile)
            {
                currentSelectedTile = selectedTile;
                highlightGO.transform.position = currentSelectedTile.tilePosition;  
            }
            highlightGO.SetActive(true);
        }

        else
        {
            currentSelectedTile = null;
            highlightGO.SetActive(false);

        }
    }

    // maybe to be put in a mother class. Something like "State". If even necessary in the first place..
    private void UpdateCurrentLookHit()
    {
        currentLookHit = player.GetLookHit();
    }
}
