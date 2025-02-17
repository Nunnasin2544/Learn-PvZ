using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    [SerializeField] private BulletData bulletData;

    private void Start()
    {
        Destroy(gameObject, bulletData.LifeTime);
    }

    private void FixedUpdate()
    {
        transform.Translate(bulletData.Speed * Time.deltaTime * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("zombie"))
        {
            collision.GetComponent<ZombieObject>().TakeDamage(bulletData.Damage);
            Destroy(gameObject);
        }
    }
}
