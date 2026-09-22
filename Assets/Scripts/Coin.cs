using Unity.Cinemachine;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinManager coinManager;
    [SerializeField] private int value;

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            CoinManager coinManager = collision.GetComponent<CoinManager>(); // if collides with player, finds coinmanager script

            if (coinManager != null)
            {
                Debug.Log("coin picked up!");
                coinManager.AddCurrency(value); // this changes the value of the coin, etc 1 gold coin is 100 currency
                Destroy(gameObject);
            }
        }
    }
}
