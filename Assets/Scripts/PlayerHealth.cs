using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Slider slider;
    public Animator anim;

    public TMP_Text healthText;

    public static event Action OnPlayerDied;

    private void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
        healthText.text = currentHealth + " / 100";

        anim = GetComponent<Animator>();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        slider.value = currentHealth;
        healthText.text = currentHealth + " / 100";

        if (amount < 0)
        {
            anim.SetTrigger("isHit");
            Debug.Log("player hit!");
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            OnPlayerDied.Invoke();
        }
    }

}
