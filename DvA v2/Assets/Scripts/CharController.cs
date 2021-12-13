// credit to danielkwood for the code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {

        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");
        

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
