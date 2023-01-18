using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePurchaseable : MonoBehaviour
{
    // The audio clip to be played when a tile is built.
    public AudioClip buildAudio;

    // The parent of the clicked tile, basically the processor.
    private GameObject targetTile;
    // The behaviour of this processor.
    private TileProcessorBehaviour processorBehaviour;
    // The audio source of the processor.
    private AudioSource processorSource;

    void Awake()
    {
        // Get the root of the clicked tile.
        targetTile = transform.parent.gameObject;
        processorBehaviour = targetTile.GetComponent<TileProcessorBehaviour>();
        processorSource = targetTile.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // Cast a raycast from the camera's position to the player's mouse position.
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                // If it is hit, check if the collider is the same as the one of this tile.
                if (raycastHit.collider.gameObject == gameObject)
                {
                    OnClicked();
                }
            }
        }        
    }

    void OnClicked()
    {
        // If the tile is a "purchaseable" tile (i.e. not a processor), set the tile the player is holding.
        if (targetTile.tag.Equals("Purchaseable")) ProcessPurchaseable();
        // Else process a "buying" phase.
        else ProcessTile();
    }

    void ProcessPurchaseable()
    {
        var gameState = GameState.Instance;

        switch (targetTile.name)
        {
            case "TileTurbine":
                gameState.TypeInHand = GameState.BuildingType.Turbine;
                break;
            case "TileSolar":
                gameState.TypeInHand = GameState.BuildingType.Solar;
                break;
            case "TileFactory":
                gameState.TypeInHand = GameState.BuildingType.Factory;
                break;
        }
    }

    void ProcessTile()
    {
        var gameState = GameState.Instance;
        var targetType = gameState.TypeInHand;

        // If the tile clicked and the one in hand are the same, ignore the request.
        if (targetType.Equals(processorBehaviour.MyType)) return;

        // If the tile is not occupied, check if the player has enough money.
        if (gameState.Money < GameState.BuildingCosts[(int)targetType]) return;

        // If the player has enough money, subtract the cost from the player's money and set the tile type.
        gameState.Money -= GameState.BuildingCosts[(int)targetType];
        processorBehaviour.MyType = targetType;

        // Play the build audio.
        if (processorSource != null) processorSource.PlayOneShot(buildAudio);
    }
}
