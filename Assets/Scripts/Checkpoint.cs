using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private SpriteRenderer sr;
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.white;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.color = inactiveColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager pm = other.GetComponent<PlayerManager>();
            if (pm != null)
            {
                pm.SetCheckpoint(transform.position);
                if (sr != null)
                    sr.color = activeColor;
            }
        }
    }
}
