using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    private float _previousDemandRun = 0f;
    private float _previousDemandIncreaseRun = 0f;
    private float _previousPollutionRun = 0f;

    void Update()
    {
        var gameState = GameState.Instance;
        if (_previousDemandRun + 1f < Time.time)
        {
            _previousDemandRun = Time.time;

            gameState.Energy = CountEnergy();

            if (gameState.Energy < gameState.EnergyDemand)
            {
                gameState.EnergyTimer--;
            }
        }

        if (_previousDemandIncreaseRun + 20f < Time.time)
        {
            _previousDemandIncreaseRun = Time.time;
            gameState.EnergyDemand += gameState.EnergyDemand;
        }

        if (_previousPollutionRun + 10f < Time.time)
        {
            _previousPollutionRun = Time.time;
            gameState.Pollution += CountPollution();
        }

        if (gameState.Pollution > 100)
        {
            // Load next Stage
        }
    }

    public static float CountPollution()
    {
        var pollution = 0f;
        var tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (var tile in tiles)
        {
            var tileProcessor = tile.GetComponent<TileProcessorBehaviour>();
            if (tileProcessor != null && tileProcessor.MyType != null)
            {
                pollution += GameState.BuildingPollution[(int)tileProcessor.MyType];
            }
        }

        return pollution;
    }

    public static float CountEnergy()
    {
        var energy = 0f;
        var tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (var tile in tiles)
        {
            var tileProcessor = tile.GetComponent<TileProcessorBehaviour>();
            if (tileProcessor != null && tileProcessor.MyType != null)
            {
                energy += GameState.BuildingEnergy[(int)tileProcessor.MyType];
            }
        }
        return energy;
    }
}
