using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Transform attackPoint;
    public float weaponRange = 1;
    public LayerMask enemyLayer;
    public int damage = 1;

    public float knockbackTime = 1;
    public float stunTime = 0.3f;
    public float knockbackForce = 50;

    public Animator anim;
    public float cooldown = 2;
    private float timer;
    public bool isAttacking;

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (timer <= 0)
        {
            isAttacking = true;
            anim.SetBool("isAttacking", true);

            timer = cooldown;
        }
    }

    public void DealDamage()
    {

        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);
        if (enemies.Length > 0)
        {
            for(int enemyIndex = 0; enemyIndex < enemies.Length; enemyIndex++) // forloop checks for enemies until enemy number is less than the index
            {
                enemies[enemyIndex].GetComponent<EnemyHealth>().ChangeHealth(-damage);
                enemies[enemyIndex].GetComponent<EnemyKnockback>().Knockback(transform, knockbackForce, knockbackTime, stunTime);
            }
        }

    }

    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
