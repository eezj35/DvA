using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    private bool mustFlip;
    public float patrolSpeed;
    public bool mustPatrol; // patrol until false
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public LayerMask collectableLayer;
    public LayerMask playerLayer;
    public Collider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol == true)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol == true)
        {
            // returns true if circle ground, false otherwise
            mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustFlip == true || bodyCollider.IsTouchingLayers(collectableLayer) || bodyCollider.IsTouchingLayers(playerLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(patrolSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        //mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        patrolSpeed *= -1;
        //mustPatrol = true;
        mustFlip = false;
    }
}
