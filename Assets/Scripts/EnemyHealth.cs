using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;

    private SlimeMovement slimeMovement;

    [Header("Loot")]
    public List<LootItem> lootTable = new List<LootItem>();

    private void Start()
    {
        currentHealth = maxHealth;
        slimeMovement = GetComponent<SlimeMovement>();
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (slimeMovement != null)
        {
            slimeMovement.ChangeState(EnemyState.Hit);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
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

