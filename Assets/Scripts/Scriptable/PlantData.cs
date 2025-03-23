using UnityEngine;

[CreateAssetMenu(fileName = "PlantData", menuName = "Game Data/Plant")]
public class PlantData : ScriptableObject
{
    public int ID;
    public string Name;
    public float Health;
    public float Damage;
    public float AttackDelay;
    public GameObject ObjectSpawn;
}