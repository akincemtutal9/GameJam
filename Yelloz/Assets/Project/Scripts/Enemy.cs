using UnityEngine;
public class Enemy : MonoBehaviour
{
    private int health;
    [SerializeField] private EnemyType enemyType;
    private string enemyName; // Name of the enemy
    private int maxHealth; // Maximum health of the enemy
    private int damage; // Damage dealt by the enemy
    private float moveSpeed; // Movement speed of the enemy
    private LayerMask layerMask;

    private void Start(){        
        enemyName = enemyType.enemyName;
        maxHealth = enemyType.maxHealth;
        damage = enemyType.damage;
        moveSpeed = enemyType.moveSpeed;
        layerMask = enemyType.layerMask;
        health = maxHealth;        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            Die();
        }
    }
    public void TakeSpecialDamage(int damage)
    {
        health -= damage * 2; // Special damage does double damage
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }   
}