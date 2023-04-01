using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackRate = 2f;
    private Animator animator;
    private float nextAttackTime = 0f;

    public int AttackDamage { get => attackDamage; set => attackDamage = value; }

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
                nextAttackTime = Time.time + 1f / attackRate;
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                SpecialAttack();
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
  