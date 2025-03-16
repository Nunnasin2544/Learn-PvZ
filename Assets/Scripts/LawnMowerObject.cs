using UnityEngine;

public class LawnMowerObject : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 originalVelocity;

    private bool isActive = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("zombie"))
        {
            if (!isActive)
            {
                isActive = true;
                originalVelocity = new Vector2(moveSpeed, 0);
                rb.velocity = originalVelocity;
                Destroy(collision.gameObject);
                Destroy(gameObject, 5f);
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
