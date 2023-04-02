using UnityEngine;
public class Enemy : MonoBehaviour
{
    private GameObject canvas;
    private int health;
    [SerializeField] private EnemyType enemyType;
    private string enemyName; // Name of the enemy
    private int maxHealth; // Maximum health of the enemy
    public static int killCount;
    public GameObject audioObj;
    private void Start()
    {
        audioObj = GameObject.FindGameObjectWithTag("AudioPlayer");
        canvas = GameObject.FindGameObjectWithTag("UpgradeCanvas");
        enemyName = enemyType.enemyName;
        maxHealth = enemyType.maxHealth;
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
        killCount++;
        Player.XP++;
        Debug.Log(Player.XP);

        if (Player.XP == 20)
        {
            ShowUpgradeCanvas();
            Player.XP = 0;
        }
        audioObj.GetComponent<AudioPlayer>().PlayEnemyDie();
        Destroy(gameObject);
    }
    public void ShowUpgradeCanvas()
    {
        Transform panel = canvas.transform.GetChild(0);
        panel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}