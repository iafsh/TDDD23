using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private float Speed;

    private bool allowedToMove;
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private bool towardRight = true;
    private Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!towardRight)
            {
                spriteRenderer.flipX = false;
                towardRight = true;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (towardRight)
            {
                spriteRenderer.flipX = true;
                towardRight = false;
            }
        }
        if (Speed != 0)
        {
            animator.SetBool("walking", true);

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                Speed *= 2;
                animator.SetBool("running", true);
            }
            else
            {
                animator.SetBool("running", false);
            }
        }
        else
        {
            animator.SetBool("walking", false);
            animator.SetBool("running", false); // Ensure "running" is set to false when not moving
        }

        rb.velocity = new Vector2(Speed * 10f, rb.velocity.y);

    }

}