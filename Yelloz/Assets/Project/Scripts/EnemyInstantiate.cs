using UnityEngine;
public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // The prefab for the enemy to be instantiated
    [SerializeField] private float spawnInterval = 1f; // The interval between enemy spawns
    private float timeSinceLastSpawn = 0f; // The time elapsed since the last spawn

    private void Start(){
        Instantiate(enemyPrefab, transform.position, transform.rotation);

    }
    // private void Update()
    // {
    //     // Check if it's time to spawn a new enemy
    //     if (timeSinceLastSpawn >= spawnInterval)
    //     {
    //         // Instantiate a new enemy at this object's position and rotation
    //         Instantiate(enemyPrefab, transform.position, transform.rotation);
            
    //         // Reset the time since the last spawn
    //         timeSinceLastSpawn = 0f;
    //     }
        
    //     // Increment the time since the last spawn
    //     timeSinceLastSpawn += Time.deltaTime;
    // }
}