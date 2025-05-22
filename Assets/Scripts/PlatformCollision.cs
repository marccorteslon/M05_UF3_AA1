using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    private Transform originalParent;

    void Start()
    {
        // Guardamos el padre original del jugador (por defecto será null)
        originalParent = transform.parent;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con una plataforma (puedes usar una etiqueta)
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Al dejar de colisionar con la plataforma, vuelve al padre original
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = originalParent;
        }
    }
}
