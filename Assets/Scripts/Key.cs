using UnityEngine;

public class Key : MonoBehaviour
{
    private bool hasKey = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Recoger la llave
        if (other.CompareTag("Key"))
        {
            hasKey = true;
            Destroy(other.gameObject); // Elimina la llave del juego
        }

        // Abrir la puerta si tienes la llave
        if (other.CompareTag("Door") && hasKey)
        {
            Collider2D puertaCollider = other.GetComponent<Collider2D>();
            if (puertaCollider != null)
            {
                puertaCollider.enabled = false; // Desactiva colisión
            }

            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = new Color(1f, 1f, 1f, 0.5f); // Efecto visual de "abierta"
            }
        }
    }
}
