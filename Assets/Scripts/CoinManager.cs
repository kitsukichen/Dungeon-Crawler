using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int totalCoins;
    public TMP_Text coinText;

    private void Start()
    {
        coinText.text = "Coins: " + totalCoins;
    }

    public void ChangeCoin(int amount)
    {
        totalCoins += amount;
        coinText.text = "Coins: " + totalCoins;
    }
}
