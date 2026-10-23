using UnityEngine;
using UnityEngine.Audio;

public class HealthChest : MonoBehaviour
{
    public Animator anim;
    private bool isOpened;
    bool playerInRange;
    PlayerMovement player;

    public GameObject heartContainer;

    private AudioSource audioSource;
    public AudioClip openSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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

        if (isOpened) return;
        isOpened = true;

        anim.SetTrigger("Open");
        heartContainer.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<PlayerMovement>();
            playerInRange = true;
        }
    }
    public void OpenAudio()
    {
        audioSource.clip = openSound;
        audioSource.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
