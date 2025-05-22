using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Vidas")]
    public int maxLives = 3;
    private int currentLives;
    private float damageCooldown = 1f;
    private float lastDamageTime;

    [Header("Checkpoint")]
    private Vector3 respawnPosition;

    private void Start()
    {
        currentLives = maxLives;
        // Iniciar el checkpoint en la posición inicial del jugador
        respawnPosition = transform.position;
    }

    public void SetCheckpoint(Vector3 newPos)
    {
        respawnPosition = newPos;
        Debug.Log("Checkpoint actualizado a: " + newPos);
    }

    public void TakeDamage()
    {
        if (Time.time - lastDamageTime < damageCooldown)
            return;

        lastDamageTime = Time.time;
        currentLives--;

        Debug.Log("Has perdido una vida. Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            Debug.Log("¡Sin vidas! Reapareciendo...");
            currentLives = maxLives;
            Respawn();
        }
    }

    public void Die()
    {
        Debug.Log("Has muerto. Reapareciendo...");
        currentLives = maxLives;
        Respawn();
    }

    private void Respawn()
    {
        transform.position = respawnPosition;
    }

    public int GetLives()
    {
        return currentLives;
    }
}
