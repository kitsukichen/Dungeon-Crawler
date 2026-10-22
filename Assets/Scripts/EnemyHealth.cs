using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    public Slider slider;

    private SlimeMovement slimeMovement;

    [Header("Loot")]
    public List<LootItem> lootTable = new List<LootItem>();

    private void Start()
    {
        currentHealth = maxHealth;
        slimeMovement = GetComponent<SlimeMovement>();

        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        slider.value = currentHealth;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        EnemyManager.Instance.EnemyKilled();

        foreach (LootItem lootItem in lootTable)
        {
            if (Random.Range(0f, 100f) <= lootItem.dropChance)
            {
                InstantiateLoot(lootItem.itemPrefab);
            }
            break;
        }

        Destroy(gameObject);
    }

    void InstantiateLoot(GameObject loot)
    {
        if (loot)
        {
            GameObject droppedLoot = Instantiate(loot, transform.position, Quaternion.identity); //this drops loot at enemy pos

            droppedLoot.GetComponent<SpriteRenderer>();
        }
    }
}

