using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Vector3 lastCheckpointPosition;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        // Por si no ha tocado ning�n checkpoint a�n
        lastCheckpointPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpointPosition = position;
    }

    public Vector3 GetLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }
}
