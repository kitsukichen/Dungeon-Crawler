using Unity.VisualScripting;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator anim;
    public GameObject ui;
    bool playerInRange;
    bool isOpened;
    PlayerMovement player;

    


    void Update()
    {
        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                OpenChest();
            }

            Debug.Log("Player in range");
        }
    }

    public void OpenChest()
    {
        isOpened = true;
        if (ui != null) ui.SetActive(false);

        anim.SetTrigger("Open");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpened)
        {
            player = collision.GetComponent<PlayerMovement>();
            playerInRange = true;

            if (ui != null) ui.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;

            if(ui != null) ui.SetActive(false);
        }
    }
}
