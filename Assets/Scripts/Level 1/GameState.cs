using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : Singleton<GameState>
{
    public float Energy { get; set; } = 0;
    public int EnergyDemand { get; set; } = 2;
    public float EnergyTimer { get; set; } = 120f;

    public float Pollution { get; set; } = 0;

    public float Money { get; set; } = 50f;

    public BuildingType TypeInHand { get; set; } = BuildingType.Solar;

    public bool IsFailing()
    {
        return Energy < EnergyDemand;
    }

    public enum BuildingType
    {
        Factory = 0,
        Turbine = 1,
        Solar = 2,
    }

    public static readonly int[] BuildingCosts = new int[] { 50, 20, 10 };
    public static readonly float[] BuildingPollution = new float[] { 0.8f, 0.0025f, 0f };
    public static readonly int[] BuildingEnergy = new int[] { 50, 15, 5 };
    public static readonly float[] BuildingMoney = new float[] { 1.5f, 0.15f, 0.05f };
}
