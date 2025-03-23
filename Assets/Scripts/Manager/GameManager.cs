using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [ReadOnly] public int SunCost;
    [ReadOnly] public PlantObject PlantObject;
    [SerializeField] private TMP_Text SunCostText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateSunCost(int sunCost)
    {
        SunCost += sunCost;
        SunCostText.text = $"{SunCost}";
    }

    public void SelectPlantCard(PlantObject plantObject)
    {
        PlantObject = plantObject;
    }

    public void DeselectPlantCard()
    {
        PlantObject = null;
    }
}
