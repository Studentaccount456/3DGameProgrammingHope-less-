using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : Singleton<GameState>
{
    // The amount of energy supply the player has.
    public float Energy { get; set; } = 0;
    // The amount of energy demand the player needs to supply.
    public int EnergyDemand { get; set; } = 2;
    // The amount of time the player has to meet said supply.
    public float EnergyTimer { get; set; } = 120f;

    // The amount of pollution the player has.
    public float Pollution { get; set; } = 0;

    // The amount of money the player has.
    public float Money { get; set; } = 50f;

    // The type of building the player has in hand, ready to "build".
    public BuildingType TypeInHand { get; set; } = BuildingType.Solar;

    public bool IsFailing()
    {
        return Energy < EnergyDemand;
    }

    public void Reset()
    {
        Energy = 0;
        EnergyDemand = 2;
        EnergyTimer = 120f;
        Pollution = 0;
        Money = 50f;
        TypeInHand = BuildingType.Solar;
    }

    public enum BuildingType
    {
        Factory = 0,
        Turbine = 1,
        Solar = 2,
    }

    // The costs of each building, in order of the BuildingType enum.
    public static readonly int[] BuildingCosts = new int[] { 50, 20, 10 };
    // The pollution produced by each building, in order of the BuildingType enum.
    public static readonly float[] BuildingPollution = new float[] { 0.8f, 0.0025f, 0f };
    // The energy produced by each building, in order of the BuildingType enum.
    public static readonly int[] BuildingEnergy = new int[] { 50, 15, 5 };
    // The amount of money each building generates, in order of the BuildingType enum.
    public static readonly float[] BuildingMoney = new float[] { 1.5f, 0.15f, 0.05f };
}
