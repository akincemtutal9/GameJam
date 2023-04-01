using UnityEngine;
public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;

    private void Start(){
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