using UnityEngine;

public class Key : MonoBehaviour
{
    public KeyManager keyManager;
    public int value;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        keyManager.ChangeKey(value); // this changes the value of the key // aka 1 normal key = 1 key
        Destroy(gameObject);
    }

}
