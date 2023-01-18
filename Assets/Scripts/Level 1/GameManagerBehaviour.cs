using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    // The previous time the demand counter was run.
    private float _previousDemandRun = 0f;

    // The previous time the demand counter was increased.
    private float _previousDemandIncreaseRun = 0f;

    // The previous time the pollution timer was run.
    private float _previousPollutionRun = 0f;

    private void Awake()
    {
        // Reset all stats if the game restarts.
        GameState.Instance.Reset();
    }

    void Update()
    {
        var gameState = GameState.Instance;
        if (_previousDemandRun + 1f < Time.time)
        {
            _previousDemandRun = Time.time;

            gameState.Energy = CountEnergy();

            // Checks if the player has enough energy to supply the demand.
            if (gameState.Energy < gameState.EnergyDemand)
            {
                gameState.EnergyTimer--;
            }
        }

        if (_previousDemandIncreaseRun + 20f < Time.time)
        {
            _previousDemandIncreaseRun = Time.time;
            // Increases the energy demand exponentially.
            gameState.EnergyDemand += gameState.EnergyDemand;
        }

        if (_previousPollutionRun + 10f < Time.time)
        {
            _previousPollutionRun = Time.time;
            // Increases the pollution depending on factories.
            gameState.Pollution += CountPollution();
        }

        if (gameState.Pollution > 100)
        {
            // Stage 1 complete, go to next level.
            LevelHandlerBehaviour.GoToLevel("1 End");
        }
        
        if (gameState.EnergyTimer <= 0)
        {
            // Stage 1 failed, go back.
            LevelHandlerBehaviour.GoToLevel("1 GO");
        }
    }

    // Counts the amount of pollution for one tick in all tiles.
    public static float CountPollution()
    {
        var pollution = 0f;
        var tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (var tile in tiles)
        {
            var tileProcessor = tile.GetComponent<TileProcessorBehaviour>();
            if (tileProcessor != null && tileProcessor.MyType != null)
            {
                // Add the pollution from each tile up to the total.
                pollution += GameState.BuildingPollution[(int)tileProcessor.MyType];
            }
        }

        return pollution;
    }

    // Counts the amount of energy produced for one tick in all tiles.
    public static float CountEnergy()
    {
        var energy = 0f;
        var tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (var tile in tiles)
        {
            var tileProcessor = tile.GetComponent<TileProcessorBehaviour>();
            if (tileProcessor != null && tileProcessor.MyType != null)
            {
                // Add the energy from each tile up to the total.
                energy += GameState.BuildingEnergy[(int)tileProcessor.MyType];
            }
        }
        return energy;
    }
}
