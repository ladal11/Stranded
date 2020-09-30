using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Exploring,
    Terraforming,
    Building,
    Placing
}


public class PlayerStateManager : MonoBehaviour
{
    public GameState gameState;


    void Start()
    {
        // Initialize at a fixed states for dev and testing purposes.
        GameState gameState = GameState.Terraforming;
        ActivateStateScript(gameState);
    }


    void Update()
    {

    }


    public void ChangePlayerState(GameState newPlayerState)
    {
        if (newPlayerState != gameState)
        {
            DeactivateStateScript(gameState);
            gameState = newPlayerState;
            ActivateStateScript(gameState);
        }
    }

    private void ActivateStateScript(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Exploring:
                Explore exploreScript = transform.GetComponent(typeof(Explore)) as Explore;
                exploreScript.enabled = true;
                break;
            case GameState.Terraforming:
                Terraform terraformScript = transform.GetComponent(typeof(Terraform)) as Terraform;
                terraformScript.enabled = true;
                break;
        }
    }

    private void DeactivateStateScript(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Exploring:
                Explore exploreScript = transform.GetComponent(typeof(Explore)) as Explore;
                exploreScript.enabled = false;
                break;
            case GameState.Terraforming:
                Terraform terraformScript = transform.GetComponent(typeof(Terraform)) as Terraform;
                terraformScript.enabled = false;
                break;
        }
    }

}
