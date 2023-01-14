using UnityEngine;

public class TileProcessorBehaviour : MonoBehaviour
{
    public GameState.BuildingType? MyType = null;
    
    public GameObject factoryObject;
    public GameObject turbineObject;
    public GameObject solarObject;

    private float _moneyTimer = 0;

    void Start()
    {
        
    }
    
    void Update()
    {
        factoryObject.SetActive(MyType == GameState.BuildingType.Factory);
        turbineObject.SetActive(MyType == GameState.BuildingType.Turbine);
        solarObject.SetActive(MyType == GameState.BuildingType.Solar);

        if (_moneyTimer + 1f < Time.time)
        {
            _moneyTimer = Time.time;
            if (MyType != null)
            {
                GameState.Instance.Money += GameState.BuildingMoney[(int)MyType];
            }
        }
    }
}
