using UnityEngine;

public class Key : MonoBehaviour
{
    private bool hasKey = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Door") && hasKey)
        {
            Destroy(other.gameObject);
        }
    }
}
