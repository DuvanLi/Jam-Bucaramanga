using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;



public class iA : MonoBehaviour
{
    StatesBoss _bossStates;
    [SerializeField] private LayerMask whatIsWall;
    private Transform _target;
    private Vector3 _destination;
    private Vector3 _direction;
    private Quaternion _desiredRotation;
    [SerializeField] private float speed;
    private float _stoppingDistace;
    private Vector2 raydistance;

    private void Update()
    {
        switch (_bossStates)
        {
            case StatesBoss.Chase:

                if (Physics2D.OverlapCircle(transform.position, 1, whatIsWall))
                {
                    speed = -speed;
                }
                transform.Translate(2f * Time.fixedDeltaTime * speed * Vector2.right);
                movementController targetToAggro;
                var col = Physics2D.OverlapCircle(transform.position, 2);
                

                if (col.gameObject.GetComponent<movementController>() != null)
                {
                    _target = col.gameObject.GetComponent<movementController>().GetComponent<Transform>();
                    _bossStates = StatesBoss.Attack;
                }

                break;
            case StatesBoss.Attack:
                print("Attack");

                break;
        }
    }

    private movementController checkForAggro()
    {
        var ray = Physics2D.Raycast(transform.position, transform.right, 1f);
        if (ray.collider.gameObject.GetComponent<movementController>())
            return ray.collider.gameObject.GetComponent<movementController>();
        return null;
    }






}