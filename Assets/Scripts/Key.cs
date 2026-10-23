using UnityEngine;
using UnityEngine.Audio;

public class Key : MonoBehaviour
{
    public KeyManager keyManager;
    public Door doorToUnlock;
    public int value;
    public AudioSource audioSource;
    public AudioClip pickupAudio;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            keyManager.ChangeKey(value);

            AudioSource.PlayClipAtPoint(pickupAudio, transform.position);

            Destroy(gameObject);
        }
    }
}
