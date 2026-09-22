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
        slider.value = currentHealth;
        healthText.text = currentHealth + " / 100";

        StartCoroutine(TriggerHurtAnimation());

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            OnPlayerDied.Invoke();
        }
    }

    IEnumerator TriggerHurtAnimation()
    {
        anim.SetBool("isHit", true);


        yield return new WaitForSeconds(0.5f);


        anim.SetBool("isHit", false);
    }

}
