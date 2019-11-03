using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;



public class iA : MonoBehaviour
{
    StatesBoss _bossStates;
    public static bool attaking;
    public static float atk = 12;
    public float life = 1000;
    public SimpleHealthBar healthBar;
    private float maxlife;
    [SerializeField] private LayerMask whatIsWall;
    private Transform _target;
    private Vector3 _destination;
    private Vector3 _direction;
    public Vector2 offset;
    private Quaternion _desiredRotation;
    [SerializeField] private float speed;
    private float _stoppingDistace;
    private Vector2 raydistance;
    private Animator animator;
    private float timer;
    public float size;
    private float timerdelay = 2f;

    public void Start()
    {
        maxlife = life;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        healthBar.UpdateBar(life, maxlife);
        if (life <= 0)
        {
            SceneManager.LoadScene("Main");
            Destroy(gameObject);

        }
        switch (_bossStates)
        {
            case StatesBoss.idle:
                attaking = false;
                if (timer <= 0)
                {

                    timer = timerdelay;
                    _bossStates = StatesBoss.Chase;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
                break;

            case StatesBoss.Chase:
                attaking = false;
                animator.SetBool("isWalking", true);

                if (Physics2D.OverlapCircle(transform.position, 1, whatIsWall))
                {
                    speed = -speed;
                    flip();
                }
                transform.Translate(2f * Time.fixedDeltaTime * speed * Vector2.left);
                movementController targetToAggro;
                var col = Physics2D.OverlapCircle((Vector2)transform.position + offset, size);


                if (col.gameObject.GetComponent<movementController>() != null)
                {
                    _target = col.gameObject.GetComponent<movementController>().GetComponent<Transform>();
                    _bossStates = StatesBoss.Attack;
                }

                break;
            case StatesBoss.Attack:
                animator.SetBool("isWalking", false);
                if (Random.Range(0, 1) < 0.5)
                    animator.SetTrigger("Attack");
                else
                    animator.SetTrigger("Attack2");

                attaking = true;
                print("Attack");

                break;


                void flip()
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
        }
    }
    public void BackToIddle()
    {
        _bossStates = StatesBoss.idle;
        animator.SetBool("isWalking", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + offset, size);
    }

    private movementController checkForAggro()
    {
        var ray = Physics2D.Raycast(transform.position, transform.right, 1f);
        if (ray.collider.gameObject.GetComponent<movementController>())
            return ray.collider.gameObject.GetComponent<movementController>();
        return null;
    }


}