using UnityEngine;

public class Lifespan : MonoBehaviour
{
    [Header("Attributes")]
    public float lifespan;

    [Header("Values")]
    private float lifespanTimer;

    private void Update()
    {
        lifespanTimer += Time.deltaTime;

        if (lifespanTimer >= lifespan)
        {
            Destroy(gameObject);
        }
    }
}
