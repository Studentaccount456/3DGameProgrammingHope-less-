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
        if (Time.time - _lastUpdate > 0.1f)
        {
            var output = string.Empty;
            var gameState = GameState.Instance;

            output += $"Energy: <color={GetEnergyColor(gameState.Energy, gameState.EnergyDemand)}>{(int)gameState.Energy}</color>/{gameState.EnergyDemand} ";
            output += $"{(gameState.IsFailing() ? $"<color=red>{gameState.EnergyTimer}</color> seconds left!" : "")}\n";
                
            output += $"Money: <color=green>{gameState.Money.ToString("0.00")}$</color>\n";
            output += $"Pollution: <color={GetPollutionColor(gameState.Pollution)}>{gameState.Pollution.ToString("0.000")}%</color>\n";
            
            output += $"Selected: <color=yellow>{GetBuildingName(gameState.TypeInHand)}</color> (costs <color=green>{GameState.BuildingCosts[(int)gameState.TypeInHand]}$</color>)";
            output += $" (produces <color=yellow>{GameState.BuildingEnergy[(int)gameState.TypeInHand]} energy</color>)";

            UIText.text = output;
        }
    }

    public string GetPollutionColor(float pollution)
    {
        if (pollution > 100) return "#FF0000FF";

        var color = "#";
        color += ((int)Map(pollution, 0, 100, 0, 255)).ToString("X2");
        color += ((int)Map(100 - pollution, 0, 100, 0, 255)).ToString("X2");
        return color + "00FF";
    }

    public string GetEnergyColor(float energy, float demand)
    {
        if (energy < demand) return "red";
        if (energy - 20 < demand) return "yellow";
        return "green";
    }

    public string GetBuildingName(GameState.BuildingType type)
    {
        if (type.Equals(GameState.BuildingType.Factory)) return "Coal plant";
        else if (type.Equals(GameState.BuildingType.Turbine)) return "Turbine";
        else if (type.Equals(GameState.BuildingType.Solar)) return "Solar panel";
        return "Undef";
    }

    private float Map(float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }
}
