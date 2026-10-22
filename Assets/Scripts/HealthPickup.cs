using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null && playerHealth.currentHealth < playerHealth.maxHealth)
            {
                playerHealth.ChangeHealth(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
