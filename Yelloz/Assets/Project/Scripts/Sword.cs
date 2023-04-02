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
       
        if (other.CompareTag(enemyTag))
        {
            if(enemyTag == "Enemy"){
            // Deal damage to the enemy
            other.GetComponent<Enemy>().TakeDamage(weaponController.AttackDamage);
            }

            if(enemyTag == "Player"){
                other.GetComponent<Player>().TakeDamage(10);
            }

        
        }
    }
}