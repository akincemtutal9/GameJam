using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/Enemy Type")]
public class EnemyType : ScriptableObject
{
    public string enemyName; // Name of the enemy
    public int maxHealth; // Maximum health of the enemy
    public int damage; // Damage dealt by the enemy
    public float moveSpeed; // Movement speed of the enemy
}