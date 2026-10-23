using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount;

    public AudioSource audioSource;
    public AudioClip pickupAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

            if (playerHealth != null && playerHealth.currentHealth < playerHealth.maxHealth)
            {
                playerHealth.ChangeHealth(healAmount);

                AudioSource.PlayClipAtPoint(pickupAudio, transform.position);

                Destroy(gameObject);
            }
        }
    }
}
