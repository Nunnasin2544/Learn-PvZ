using UnityEngine;

public class SunObject : MonoBehaviour
{
    public int SunCost { get; private set; }

    [SerializeField] private float fallSpeed = 5f;
    private Transform floorPoint;
    private bool isfalling = false;

    public void Init(int cost, Transform floorPoint)
    {
        SunCost = cost;
        this.floorPoint = floorPoint;
        isfalling = true;
    }

    private void FixedUpdate()
    {
        if (isfalling && transform.position.y > floorPoint.position.y)
        {
            transform.Translate(fallSpeed * Time.deltaTime * Vector2.down);
        }
        else if (isfalling && transform.position.y <= floorPoint.position.y)
        {
            isfalling = false;
            Destroy(gameObject, 8f);
        }
    }
}
