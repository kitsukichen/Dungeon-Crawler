using UnityEngine;

public class Door : MonoBehaviour
{

    public bool doorUnlocked;
    bool playerInRange;
    PlayerMovement player;

    public KeyManager keyManager;
    public GameObject doorUI;
    public AudioClip openSound;
    public AudioSource audioSource;


    // Update is called once per frame
    void Update()
    {

        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                if (keyManager.totalKeys > 0)
                {
                    OpenDoor();
                }
                else
                {
                    doorUI.SetActive(true);
                }
            }
        }
    }

    public void OpenDoor()
    {
        keyManager.ChangeKey(-1);

        AudioSource.PlayClipAtPoint(openSound, transform.position);

        gameObject.SetActive(false);
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

            if (doorUI != null) doorUI.SetActive(false);
        }
    }
}
