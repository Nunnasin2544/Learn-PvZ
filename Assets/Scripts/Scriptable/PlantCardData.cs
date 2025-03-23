using UnityEngine;

[CreateAssetMenu(fileName = "PlantCardData", menuName = "Game Data/Plant Card")]
public class PlantCardData : ScriptableObject
{
    public int ID;
    public int SunCost;
    public float Cooldown;
    public string Rarity;
    public PlantObject PlantPrefab;
    public Sprite PlantSprite;
}