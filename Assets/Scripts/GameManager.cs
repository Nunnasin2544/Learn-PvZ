using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int SunCost;
    [SerializeField] private TMP_Text SunCostText;

    public void UpdateSunCost(int sunCost)
    {
        SunCost += sunCost;
        SunCostText.text = $"{SunCost}";
    }
}
