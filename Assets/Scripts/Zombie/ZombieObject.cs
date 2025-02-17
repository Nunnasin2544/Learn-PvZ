using System.Collections;
using UnityEngine;

public class ZombieObject : MonoBehaviour
{
    [SerializeField] private ZombieData zombieData;
    private float currentHealth;
    private bool isAttacking = false;
    private Rigidbody2D rb;
    private Vector2 originalVelocity;
    private Vector3 originalPosition;

    private void Start()
    {
        currentHealth = zombieData.Health;
        //GetComponent<SpriteRenderer>().sprite = zombieData.Sprite;
        originalVelocity = new Vector2(-zombieData.MoveSpeed, 0);
        originalPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = originalVelocity;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("plant") && !isAttacking)
        {
            rb.velocity = Vector2.zero;
            StartCoroutine(AttackPlant(collision));
        }

        if (collision.CompareTag("home"))
        {
            rb.velocity = Vector2.zero;
            Destroy(gameObject);
        }
    }

    private IEnumerator AttackPlant(Collider2D plant)
    {
        isAttacking = true;
        StartCoroutine(EatingAnimation());

        while (plant != null)
        {
            plant.GetComponent<PlantObject>().TakeDamage(zombieData.Damage);
            yield return new WaitForSeconds(zombieData.AttackSpeed);
        }

        isAttacking = false;
        StopCoroutine(EatingAnimation());
        transform.position = new Vector2(transform.position.x, originalPosition.y);
        rb.velocity = originalVelocity;
    }

    private IEnumerator EatingAnimation()
    {
        while (isAttacking)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
            yield return new WaitForSeconds(zombieData.AttackSpeed);

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
            yield return new WaitForSeconds(zombieData.AttackSpeed);
        }
    }
}
