using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;
    private int attackDamage;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackRate = 2f;
    private float runSpeed;
    private Animator animator;
    private Transform playerTransform;
    private float nextAttackTime = 0f;
    
    private enum EnemyState { Run, Attack }
    private EnemyState currentState = EnemyState.Run;

    public int AttackDamage { get => attackDamage; set => attackDamage = value; }

    private void Start()
    {
        runSpeed = enemyType.moveSpeed;
        AttackDamage = enemyType.damage;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(playerTransform==null){return;}
        
        switch (currentState)
        {
            case EnemyState.Run:
                Run();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            default:
                break;
        }
    }
    private void Run()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsRunning", true);

        // Rotate towards the player
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);

        // Move towards the player
        transform.position += transform.forward * runSpeed * Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= attackRange)
        {
            currentState = EnemyState.Attack;
        }
    }
    private void Attack()
    {
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsRunning", false);
        // Rotate towards the player
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        if (Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attack");
            nextAttackTime = Time.time + 1f / attackRate;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer > attackRange)
        {
            currentState = EnemyState.Run;
        }
    }
}
