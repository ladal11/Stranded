using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explore : MonoBehaviour
{
    private Player player;
    RaycastHit currentLookHit;

    private void Awake()
    {
        player = GetComponent<Player>() as Player;
    }

    private void OnEnable()
    {
        Debug.Log("Exploring...");
    }

    private void Update()
    {
        UpdateCurrentLookHit();
    }



    // maybe to be put in a mother class. Something like "State". If even necessary in the first place..
    private void UpdateCurrentLookHit()
    {
        currentLookHit = player.GetLookHit();
    }

}
