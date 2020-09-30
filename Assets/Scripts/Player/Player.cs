using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public Camera playerCamera;

    private float maxInteractionDistance = 4f;

    private PlayerStateManager playerStateManager;
    private PlayerItemManager playerItemManager;

    public Item currentItem
    {
        get
        {
            return playerItemManager.currentItem;
        }
    }

    public GameState currentGameState
    {
        get
        {
            return playerStateManager.gameState;
        }
        set
        {
            playerStateManager.ChangePlayerState(value);
        }
    }

    private void Awake()
    {
        playerStateManager = GetComponent<PlayerStateManager>();
        playerItemManager = GetComponent<PlayerItemManager>();
    }

    public RaycastHit GetLookHit()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxInteractionDistance))
        {
            return hit;
        }
        return new RaycastHit();
    }

}
