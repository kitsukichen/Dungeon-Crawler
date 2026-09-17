using UnityEngine;

public class PlantMovement : MonoBehaviour
{
    public float attackRange = 2;
    public float attackCooldown = 2;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;


    private float attackCooldownTimer;
    private PlantState enemyState;
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(PlantState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();

        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }

        if (enemyState == PlantState.Attacking)
        {
            // do attack stuff
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);

        if (hits.Length > 0)
        {
            player = hits[0].transform;

            //if player is in attack range AND cooldown is ready
            if (Vector2.Distance(transform.position, player.position) <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(PlantState.Attacking);
            }

            else if (Vector2.Distance(transform.position, player.position) > attackRange)
            {
                ChangeState(PlantState.Idle);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

    }

    void ChangeState(PlantState newState)
    {
        // exit current animation
        if (enemyState == PlantState.Idle)
            anim.SetBool("isIdle", false);
        else if (enemyState == PlantState.Attacking)
            anim.SetBool("isAttacking", false);

        enemyState = newState;

        // update new animation
        if (enemyState == PlantState.Idle)
            anim.SetBool("isIdle", true);
        else if (enemyState == PlantState.Attacking)
            anim.SetBool("isAttacking", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
}
public enum PlantState
{
    Idle,
    Attacking,
}