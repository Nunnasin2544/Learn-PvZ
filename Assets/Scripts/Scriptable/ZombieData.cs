using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "Game Data/Zombie")]
public class ZombieData : ScriptableObject
{
    public int ID;
    public string Name;
    public float Health;
    public float Damage;
    public float MoveSpeed;
    public float AttackDelay;
    public Sprite Sprite;
    public GameObject ObjectSpawn;
}