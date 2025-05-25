using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackPrefab;
    public float attackDuration = 0.2f;
    public Vector2 attackOffset = new Vector2(1f, 0f);

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Vector2 spawnPosition = (Vector2)transform.position + attackOffset;
        GameObject attack = Instantiate(attackPrefab, spawnPosition, Quaternion.identity);
        Destroy(attack, attackDuration);
    }
}
