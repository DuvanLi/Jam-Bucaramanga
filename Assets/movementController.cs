using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
   [SerializeField]private float speed;
    private float horizontal;
    private Rigidbody2D rb;
   public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        switch (horizontal)
        {
            case 0:
                //rb.velocity = new Vector2((rb.velocity.x < 0) ? rb.velocity.x+Mathf.Abs(rb.velocity.x) :,rb.velocity.y)
                rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, 5), rb.velocity.y);
                break;
            case 1:
                rb.velocity = new Vector2(speed, rb.velocity.y);
                break;
            case -1:
                rb.velocity = new Vector2(speed*-1, rb.velocity.y);
                break;
        }        
        
       
    }
        

    
}
