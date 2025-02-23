using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "Game Data/Plant")]
public class PlantData : ScriptableObject
{
    public int ID;
    public string Name;
    public int Cost;
    public float Health;
    public float Damage;
    public float AttackDelay;
    public Sprite Sprite;
    public GameObject ObjectSpawn;
}