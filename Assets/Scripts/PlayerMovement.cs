using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private float speedClamp;
    private Vector2 movementDirection;

    public bool canMove = true;

    public Animator anim;

    void Update()
    {
        if (canMove)
            Move();
        else
            rb.velocity = Vector2.zero;
    }

    private void Move()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        speedClamp = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1f);
        movementDirection.Normalize();
        rb.velocity = movementDirection * speedClamp * speed;
        anim.SetFloat("Speed", rb.velocity.magnitude);

        if (rb.velocity.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (rb.velocity.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
