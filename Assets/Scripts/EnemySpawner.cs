using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public bool spawnEnemies = true;

    public GameObject enemyPrefab;
    public float spawnInterval;

    public int maxEnemyAmount;
    public int currentEnemyAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemyAmount <= 0 && !spawnEnemies)
        {
            spawnEnemies = true;
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        Debug.Log("Spawning Enemies");
        while (spawnEnemies)
        {
            float randomX = Random.Range(-10, 10);
            float randomY = Random.Range(-6, 6);
            Vector3 randomSpawnPos = new Vector3(randomX, randomY, 0);

            Instantiate(enemyPrefab, randomSpawnPos, Quaternion.identity);
            currentEnemyAmount += 1;

            if (currentEnemyAmount >= maxEnemyAmount)
                spawnEnemies = false;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
