using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movementController : MonoBehaviour
{
    public GameObject fade;
    private Image image;
    public static float atkDamage = 1;
    public float life = 100;
    private float maxlife;
    public float mp = 100;
    private float maxMp;
    public SimpleHealthBar healthBar;
    public SimpleHealthBar mpBar;

    public static bool atacking = false;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    private float horizontal;
    private bool facingRigh;
    public Animator animator;
    public Rigidbody2D rb;
    private bool jump;
    private bool Attack1, Attack2, Shield;
    [SerializeField] private float offset;
    [SerializeField] private LayerMask whatisGround;
    [SerializeField] private Vector2 sizeBox;
    private bool isjumping;
    bool rangeAttack;

    public void Start()
    {
        maxlife = life;
        maxMp = mp;

    }
    void OnDisable()
    {
        horizontal = 0;
        animator.SetBool("isRuning", false);
        animator.StopPlayback();
    }



    void Update()
    {
        


        if (healthBar != null)
        {
            print("Vida: " + life);
            print("Stamina: " + mp);
            healthBar.UpdateBar(life, maxlife);
            if (life <= 0)
            {
                speed = 0;
                isjumping = true;
                animator.SetBool("Dead", true);
                animator.StopPlayback();

            }

        }

        horizontal = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Button_A");
        Attack1 = Input.GetButtonDown("Button_X");
        Attack2 = Input.GetButtonDown("Button_Y");
        rangeAttack = Input.GetButtonDown("Button_B");

        if (!atacking)
        {

            if (Attack1)
            {
                atacking = true;
                animator.SetTrigger("Attack1");
            }
            if (Attack2)
            {
                atacking = true;
                animator.SetTrigger("Attack2");
            }
            if (rangeAttack)
            {
                atacking = true;
                animator.SetTrigger("RangeAttack");
            }
        }
    }

    public void EndAttack()
    {
        print("End attack");
        atacking = false;
    }

    void FixedUpdate()
    {
        if (life <= 0)
        {
            if (fade != null)
                fade.SetActive(true);
        }
        if (rb.isKinematic)
        {
            animator.SetBool("isRuning", false);
        }


        //var xSpeed = rb.velocity.x + (horizontal * speed) * Time.deltaTime;
        //var targetVelocity = rb.velocity.x + (horizontal * speed) * Time.deltaTime;

        //rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x,targetVelocity,1f), rb.velocity.y);*/



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

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = false;
            EndAttack();
        }
    }

    void flip()
    {
        print("Making FLIP NOW");
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(new Vector2(transform.position.x, transform.position.y - offset), sizeBox);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject);
        if (other.gameObject.GetComponent<EnemyHitBox>() != null)
        {
            if (iA.attaking)
            {
                life -= iA.atk;
                animator.SetTrigger("takingDamage");
            }

        }
    }


}

