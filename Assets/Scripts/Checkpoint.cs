using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.CompleteScreen();
        }
    }
}
