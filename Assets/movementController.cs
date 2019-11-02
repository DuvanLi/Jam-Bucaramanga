using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
   [SerializeField]private float speed;
    private float horizontal;
    private bool facingRigh;
    private Animator animator;
    private Rigidbody2D rb;
    
   public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        print(horizontal);
        

    }

    void FixedUpdate()
    {
        print("X Velocity: " + rb.velocity.x);
        //var xSpeed = rb.velocity.x + (horizontal * speed) * Time.deltaTime;
        //var targetVelocity = rb.velocity.x + (horizontal * speed) * Time.deltaTime;

        //rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x,targetVelocity,1f), rb.velocity.y);*/

        if(rb.velocity.x >= 0.1 && facingRigh)
            {
            flip();
            facingRigh = !facingRigh;
        }
        if (rb.velocity.x <= -0.1 && !facingRigh)
        {
            flip();
            facingRigh = !facingRigh;
        }
            switch (horizontal)
        {
            case 0:
                //rb.velocity = new Vector2((rb.velocity.x < 0) ? rb.velocity.x+Mathf.Abs(rb.velocity.x) :,rb.velocity.y)
                rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 5), rb.velocity.y);
                animator.SetBool("isRuning", false);
                break;
            case 1:                
                rb.velocity = new Vector2(speed, rb.velocity.y);
                animator.SetBool("isRuning", true);
                break;
            case -1:
                rb.velocity = new Vector2(speed*-1, rb.velocity.y);
                animator.SetBool("isRuning", true);
                break;
        }        
        
       void flip()
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
       
        }


    }
        

    
}
