using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePurchaseable : MonoBehaviour
{
    private GameObject targetTile;
    private TileProcessorBehaviour processorBehaviour;

    void Awake()
    {
        targetTile = transform.parent.gameObject;
        processorBehaviour = targetTile.GetComponent<TileProcessorBehaviour>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.gameObject == gameObject)
                {
                    OnClicked();
                }
            }
        }        
    }

    void OnClicked()
    {
        if (targetTile.tag.Equals("Purchaseable")) ProcessPurchaseable();
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

        if (targetType.Equals(processorBehaviour.MyType)) return;

        if (gameState.Money < GameState.BuildingCosts[(int)targetType]) return;

        gameState.Money -= GameState.BuildingCosts[(int)targetType];
        processorBehaviour.MyType = targetType;
    }
}
