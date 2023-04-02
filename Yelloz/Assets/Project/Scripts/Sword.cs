using UnityEngine;

public class Sword : MonoBehaviour
{
    public string enemyTag = "Enemy"; // Tag of the enemy

    private WeaponController weaponController;
    private EnemyBehavior enemyBehavior;
    

    private void Start(){
        weaponController = GetComponentInParent<WeaponController>();
        enemyBehavior = GetComponentInParent<EnemyBehavior>();
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag(enemyTag))
        {
            if(enemyTag == "Enemy"){
                if(Random.value <= weaponController.CritChance)
                weaponController.AttackDamage *= 2;
            // Deal damage to the enemy
            other.GetComponent<Enemy>().TakeDamage(weaponController.AttackDamage);
            }

            if(enemyTag == "Player"){
                other.GetComponent<Player>().TakeDamage(enemyBehavior.AttackDamage);
            }

        
        }
    }
}