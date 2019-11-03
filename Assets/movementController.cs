using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    private float horizontal;
    private bool facingRigh;
    public Animator animator;
    public Rigidbody2D rb;
    private bool jump;
    [SerializeField] private float offset;
    [SerializeField] private LayerMask whatisGround;
    [SerializeField] private Vector2 sizeBox;
    private bool isjumping;

    public void Start()
    {
    }
    void OnDisable()
    {
        horizontal = 0;
        animator.SetBool("isRuning", false);
        animator.StopPlayback();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        print(horizontal);

        jump = Input.GetButtonDown("Button_A");
    }

    void FixedUpdate()
    {
        if (rb.isKinematic)
            animator.SetBool("isRuning", false);

        print("X Velocity: " + rb.velocity.x);
        //var xSpeed = rb.velocity.x + (horizontal * speed) * Time.deltaTime;
        //var targetVelocity = rb.velocity.x + (horizontal * speed) * Time.deltaTime;

        //rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x,targetVelocity,1f), rb.velocity.y);*/

        if (rb.velocity.x >= 0.1 && facingRigh)
        {
            flip();
            facingRigh = !facingRigh;
        }

        if (rb.velocity.x <= -0.1 && !facingRigh)
        {
            flip();
            facingRigh = !facingRigh;
        }

        if (horizontal == 0)
        {
            //rb.velocity = new Vector2((rb.velocity.x < 0) ? rb.velocity.x+Mathf.Abs(rb.velocity.x) :,rb.velocity.y)
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 5), rb.velocity.y);
            animator.SetBool("isRuning", false);
        
        }

        if (horizontal > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.SetBool("isRuning", true);
        }

        if (horizontal < 0)
        {

            rb.velocity = new Vector2(speed * -1, rb.velocity.y);
            animator.SetBool("isRuning", true);
        }



        if (jump && !isjumping)
        {
            rb.AddForce(Vector2.up * jumpForce);
            animator.SetTrigger("Jump");
            isjumping = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            isjumping = false;
    }

    void flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y - offset), sizeBox);
    }
}