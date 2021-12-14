// credit to danielkwood for the code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    float horizontalMove = 0f;

    private Rigidbody2D player;
    private BoxCollider2D boxCollider2d;
    
    public Transform groundCheck;
    public float groundCheckRadius;
    private bool isGrounded;
    public LayerMask platformsLayerMask;
    private bool facingRight = true;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, platformsLayerMask);
        direction = Input.GetAxis("Horizontal");

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (!isGrounded)
        {
            animator.SetBool("isJumping", true);
        } else
        {
            animator.SetBool("isJumping", false);
        }

        if (direction > 0f && !facingRight)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            Flip();
        }
        else if (direction < 0f && facingRight)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            Flip();
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
        
        transform.position += new Vector3(direction, 0, 0) * Time.deltaTime * speed;
    }




    private void Flip()
    {
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
