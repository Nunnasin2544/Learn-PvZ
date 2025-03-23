using System;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static ClickManager Instance { get; private set; }

    public event Action OnClickInput;

    private GameManager gameManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.CompareTag("sun"))
            {
                SunObject sun = hit.collider.gameObject.GetComponent<SunObject>();
                gameManager.UpdateSunCost(sun.SunCost);
                Destroy(sun.gameObject);
            }

            OnClickInput?.Invoke();
        }
    }
}
