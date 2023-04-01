using UnityEngine;

public class Sword : MonoBehaviour
{
    public string enemyTag = "Enemy"; // Tag of the enemy

    private WeaponController weaponController;

    private void Start(){
        weaponController = GetComponentInParent<WeaponController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other collider has the enemy tag
        if (other.CompareTag(enemyTag))
        {
            // Deal damage to the enemy
            other.GetComponent<Enemy>().TakeDamage(weaponController.AttackDamage);
        }
    }
}