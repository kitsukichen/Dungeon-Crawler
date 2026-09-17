using TMPro;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public int totalKeys;
    public TMP_Text keyText;


    void Start()
    {
        keyText.text = "Keys: " + totalKeys;
    }

    public void ChangeKey(int amount)
    {
        totalKeys += amount;
        keyText.text = "Keys: " + totalKeys;
    }
}
