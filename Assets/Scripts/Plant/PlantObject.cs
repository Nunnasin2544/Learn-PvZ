using System.Collections;
using UnityEngine;

public class PlantObject : MonoBehaviour
{
    [SerializeField] private PlantData plantData;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform floorPoint;
    private float currentHealth;

    private void Start()
    {
        currentHealth = plantData.Health;
        //GetComponent<SpriteRenderer>().sprite = plantData.Sprite;
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            OnSpawn();
            yield return new WaitForSeconds(plantData.AttackDelay);
        }
    }

    private void OnSpawn()
    {
        GameObject spawnObject = 
            Instantiate(
                plantData.ObjectSpawn, 
                spawnPoint.position, 
                Quaternion.identity
            );
        spawnObject.transform.SetParent(spawnPoint);

        if (spawnObject.CompareTag("sun"))
            spawnObject.GetComponent<SunObject>().Init((int)plantData.Damage ,floorPoint);
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
