using UnityEngine;

public class HealthChest : MonoBehaviour
{
    public Animator anim;
    bool playerInRange;
    PlayerMovement player;

    public GameObject heartContainer;


    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                OpenChest();
            }
        }
    }

    public void OpenChest()
    {

        if (playerInRange)
        {
            if (player.playerInteracting)
            {

                anim.SetTrigger("Open");
                heartContainer.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerMovement>();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
