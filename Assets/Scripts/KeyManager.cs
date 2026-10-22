using TMPro;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public int totalKeys;
    public TMP_Text keyText;


    void Start()
    {
        keyText.text = "x " + totalKeys;
    }

    public void ChangeKey(int amount)
    {
        totalKeys += amount;
        keyText.text = "x " + totalKeys;
    }
}
