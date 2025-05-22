using UnityEngine;

public class AttackArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);  // Elimina al enemigo
        }
    }
}
