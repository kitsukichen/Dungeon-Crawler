using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movementInput;
    public float speed = 5;
    public Rigidbody2D rb;
    public Animator anim;
    public PlayerCombat playerCombat;
    public bool playerInteracting; // is my key being pressed ? yes or no

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

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.started) // is e being pressed?
        {
            playerInteracting = true;
            Debug.Log("pressed e");
        }
        else if (context.canceled) // has the player let go?
        {
            playerInteracting = false;
        }
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
        if (playerCombat.isAttacking)
        {
            return; // stops the flip sprite function
        }

        if (movementInput.x > 0)
        {
            spriteRenderer.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementInput.x < 0)
        {
            spriteRenderer.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
