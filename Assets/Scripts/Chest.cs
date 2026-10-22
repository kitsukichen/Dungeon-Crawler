using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour
{
    public Animator anim;
    public GameObject ui;
    public GameObject quest;
    public GameObject key;

    bool playerInRange;
    bool isOpened;
    bool hasInteracted;
    private bool messageShown = false;
    PlayerMovement player;

    [Header("Unlock Requirements")]
    public int enemiesRequired = 5;

    [Header("Chest UI")]
    public TMP_Text questText;



    void Update()
    {
        if (playerInRange)
        {
            if (player.playerInteracting)
            {
                OpenChest();
            }
        }

        if (hasInteracted && !messageShown)
        {
            if (EnemyManager.Instance.enemiesKilled >= enemiesRequired)
            {
                questText.text = "Quest Complete! All enemies defeated!";
            }
            else
            {
                questText.text = $"Enemies Defeated: {EnemyManager.Instance.enemiesKilled} / 20";
            }
        }
    }

    public void OpenChest()
    {

        if (EnemyManager.Instance.enemiesKilled < enemiesRequired)
        {
            if (!hasInteracted)
            {
                hasInteracted = true;
                StartCoroutine(Message());
            }

            return;
        }

        isOpened = true;
        if (ui != null) ui.SetActive(false);

        if (quest != null) quest.SetActive(false);

        anim.SetTrigger("Open");

        key.SetActive(true);
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

    IEnumerator Message()
    {
        messageShown = true;

        questText.text = "Locked! Defeat all enemies to open";

        yield return new WaitForSeconds(2f);

        messageShown = false;
    }
}
