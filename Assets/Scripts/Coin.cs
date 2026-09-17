using Unity.Cinemachine;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public CoinManager coinManager;
    public int value;

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            coinManager.ChangeCoin(value); // this changes the value of the coin, etc 1 gold coin is 100 currency
            Destroy(gameObject);
        }
    }
}
