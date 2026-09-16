using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movementInput;
    public float speed = 5;
    public Rigidbody2D rb;
    public Animator anim;
    public PlayerCombat playerCombat;


    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called 50x per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementInput.x * speed, movementInput.y * speed); //top down movement
        FlipSprite();

        anim.SetFloat("horizontal", Mathf.Abs(movementInput.x));
        anim.SetFloat("vertical", Mathf.Abs(movementInput.y));
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>(); //this gets input
    }

    public void OnAttackEvent(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Attack!)");
            playerCombat.Attack();
        }
    }

    void FlipSprite()
    {
        if (movementInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
