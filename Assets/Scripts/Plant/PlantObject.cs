using UnityEngine;

public class PlantObject : MonoBehaviour
{
    [SerializeField] private PlantData plantData;
    private float currentHealth;

    private void Start()
    {
        currentHealth = plantData.Health;
        //GetComponent<SpriteRenderer>().sprite = plantData.Sprite;
        InvokeRepeating(nameof(Shoot), 0, plantData.AttackSpeed);
    }

    private void Shoot()
    {
        Instantiate(plantData.ObjectSpawn, transform.position, Quaternion.identity);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
