using UnityEngine;

public class Enemy_Chase : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float stopDistance = 1.5f;
    public float damageAmount = 10f;
    public float damageCooldown = 1f;

    private float lastDamageTime;

    void Update()
    {
        if (player == null) return;

        Vector3 targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        float distance = Vector3.Distance(transform.position, targetPos);

        if (distance > stopDistance)
        {
            Vector3 direction = (targetPos - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;

            if (direction != Vector3.zero)
            {
                transform.forward = direction;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (Time.time >= lastDamageTime + damageCooldown)
        {
            Player_Health health = other.GetComponent<Player_Health>();

            if (health != null)
            {
                health.TakeDamage(damageAmount);
                lastDamageTime = Time.time;
            }
        }
    }
}