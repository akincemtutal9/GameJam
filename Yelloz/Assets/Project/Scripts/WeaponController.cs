using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float critChance = 0f;
    [SerializeField] private float attackRate = 2f;
    private Animator animator;
    private float nextAttackTime = 0f;

    public GameObject audioObj;
    
    public int AttackDamage { get => attackDamage; set => attackDamage = value; }
    public float CritChance { get => critChance; set => critChance = value; }

    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }
    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                audioObj.GetComponent<AudioPlayer>().PlayAttack1();     
                nextAttackTime = Time.time + 1f / attackRate;
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                SpecialAttack();
                audioObj.GetComponent<AudioPlayer>().PlayAttack2();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    private void Attack()
    {
        animator.SetTrigger("Attack1");
         
    }
    private void SpecialAttack()
    {
        animator.SetTrigger("Attack2");
    }    
}
  