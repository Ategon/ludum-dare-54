using UnityEngine;

public class ShieldCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("AAAAA");
        Destroy(collision.gameObject);
    }
}
