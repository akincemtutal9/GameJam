using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    public static int XP;
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }

    public GameObject loseUI;

    public GameObject audioObj;

    public Slider slider;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        slider.value = 1;
    }

    private void Update(){
        slider.value = (float) currentHealth/maxHealth;
    }
    
    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        Debug.Log(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        audioObj.GetComponent<AudioPlayer>().PlayCharacterDie();
        Destroy(gameObject);
        loseUI.SetActive(true);
        Debug.Log("Player died!");
    }
}
