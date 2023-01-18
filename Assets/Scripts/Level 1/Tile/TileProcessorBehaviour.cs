using UnityEngine;

public class TileProcessorBehaviour : MonoBehaviour
{
    // The building type that is currently occupied by this tile.
    public GameState.BuildingType? MyType = null;
    
    // The factory object that needs to be toggled.
    public GameObject factoryObject;
    // The turbine object that needs to be toggled.
    public GameObject turbineObject;
    // The solar object that needs to be toggled.
    public GameObject solarObject;

    // The last time the building has given money to the user.
    private float _moneyTimer = 0;

    void Start()
    {
        
    }
    
    void Update()
    {
        
        // Set all tiles to their corresponding types.
        factoryObject.SetActive(MyType == GameState.BuildingType.Factory);
        turbineObject.SetActive(MyType == GameState.BuildingType.Turbine);
        solarObject.SetActive(MyType == GameState.BuildingType.Solar);

        // Tick every second.
        if (_moneyTimer + 1f < Time.time)
        {
            _moneyTimer = Time.time;
            if (MyType != null)
            {
                // If the tile is occupied, give the corresponding amount of money.
                GameState.Instance.Money += GameState.BuildingMoney[(int)MyType];
            }
        }
    }
}
