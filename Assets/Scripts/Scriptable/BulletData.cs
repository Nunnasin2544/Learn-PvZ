using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Game Data/Bullet")]
public class BulletData : ScriptableObject
{
    public int ID;
    public float Damage;
    public float Speed;
    public Sprite Sprite;
}