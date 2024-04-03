using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player; 
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    private float dirX = 0;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask jumpableGround;

    public int reversed = 1;


    private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start");
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        
        
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(dirX * speed, player.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded()) // on saute
        {
            Debug.Log("jsuis la ?");
            player.velocity = new Vector2(player.velocity.x, reversed*jumpForce);
        }

        UpdateAnimation();
        
    }

    // Fait la bonne animation en fct de la situation
    private void UpdateAnimation()
    {

        MovementState state;

        if(dirX > 0f) // On va a droite
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if(dirX < 0f) // on va a gauche
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else // il bouge pas
        {
            state = MovementState.idle;
        }

        if (player.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (player.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down, reversed*0.1f,jumpableGround);
    }
}
