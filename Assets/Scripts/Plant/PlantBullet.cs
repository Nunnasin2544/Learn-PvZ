using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    [SerializeField] private BulletData bulletData;
    private bool hasHit = false;

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
        if (!hasHit && collision.CompareTag("zombie"))
        {
            hasHit = true;
            collision.GetComponent<ZombieObject>().TakeDamage(bulletData.Damage);
            Destroy(gameObject);
        }
    }
}
