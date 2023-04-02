using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay = 3f;
    [SerializeField] private int maxEnemies = 10;

    private int currentEnemies = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (currentEnemies < maxEnemies)
        {
            // Instantiate an enemy prefab at this spawner's position and rotation
            GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
            
            // Increment the number of current enemies
            currentEnemies++;
            
            // Wait for the spawn delay before spawning the next enemy
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void EnemyDestroyed()
    {
        // Decrement the number of current enemies when an enemy is destroyed
        currentEnemies--;
    }
}