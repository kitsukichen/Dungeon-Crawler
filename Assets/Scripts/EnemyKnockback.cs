using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class EnemyKnockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private SlimeMovement slimeMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slimeMovement = GetComponent<SlimeMovement>();
    }
    public void Knockback(Transform playerTransform, float knockbackForce, float knockbackTime, float stunTime)
    {
        slimeMovement.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.linearVelocity = direction * knockbackForce;
       
        Debug.Log("knockback applied");
    }

    IEnumerator StunTimer(float knockbackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        slimeMovement.ChangeState(EnemyState.Idle);
    }
}