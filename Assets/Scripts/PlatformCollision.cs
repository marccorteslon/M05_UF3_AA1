using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    private Transform originalParent;

    void Start()
    {
        originalParent = transform.parent;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = originalParent;
        }
    }
}
