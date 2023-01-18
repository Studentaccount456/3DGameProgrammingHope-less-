using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasUpdaterBehaviour : MonoBehaviour
{
    private TextMeshProUGUI UIText;
    private float _lastUpdate = 0;
    
    void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Only update the text every 0.1 seconds.
        if (Time.time - _lastUpdate > 0.1f)
        {
            var output = string.Empty;
            var gameState = GameState.Instance;

            // Add the energy demand to the output.
            output += $"Energy: <color={GetEnergyColor(gameState.Energy, gameState.EnergyDemand)}>{(int)gameState.Energy}</color>/{gameState.EnergyDemand} ";
            output += $"{(gameState.IsFailing() ? $"<color=red>{gameState.EnergyTimer}</color> seconds left!" : "")}\n";

            // Add the money to the output.
            output += $"Money: <color=green>{gameState.Money.ToString("0.00")}$</color>\n";

            // Add the pollution to the output.
            output += $"Pollution: <color={GetPollutionColor(gameState.Pollution)}>{gameState.Pollution.ToString("0.000")}%</color>\n";

            // Add the current type in hand to the output.
            output += $"Selected: <color=yellow>{GetBuildingName(gameState.TypeInHand)}</color> (costs <color=green>{GameState.BuildingCosts[(int)gameState.TypeInHand]}$</color>)";
            output += $" (produces <color=yellow>{GameState.BuildingEnergy[(int)gameState.TypeInHand]} energy</color>)";

            UIText.text = output;
        }
    }

    // Will return a color code representing the amount of pollution.
    public string GetPollutionColor(float pollution)
    {
        if (pollution > 100) return "#FF0000FF";

        var color = "#";
        // Will map the value of pollution from 0-255 in hexadecimal.
        color += ((int)Map(pollution, 0, 100, 0, 255)).ToString("X2");
        // Will map the value of 100% - pollution from 0-255 in hexadecimal.
        color += ((int)Map(100 - pollution, 0, 100, 0, 255)).ToString("X2");
        return color + "00FF";
    }

    // Will return a color code representing the amount of energy.
    public string GetEnergyColor(float energy, float demand)
    {
        if (energy < demand) return "red";
        if (energy - 20 < demand) return "yellow";
        return "green";
    }

    // Will return the name of the building.
    public string GetBuildingName(GameState.BuildingType type)
    {
        if (type.Equals(GameState.BuildingType.Factory)) return "Coal plant";
        else if (type.Equals(GameState.BuildingType.Turbine)) return "Turbine";
        else if (type.Equals(GameState.BuildingType.Solar)) return "Solar panel";
        return "Undef";
    }

    // Will map a value from a range to another range.
    private float Map(float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }
}
