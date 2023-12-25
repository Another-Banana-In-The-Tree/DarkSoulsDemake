using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Skeleton : Enemy 
{

    [field: Header("Movement")]
    [SerializeField] private float radius;
    [SerializeField] private float angle;
    [SerializeField] private LayerMask obstructMask;
    [SerializeField] private float stoppingDistance;
    //[SerializeField] private Transform playerPos;

    //[field: Header("Combat")]
    

    private void FixedUpdate()
    {
        if (FieldOfViewCheck())
        {
            canWalk = true;
            UpdatePath();
            Move();
        }
        else
        {
            canWalk = false;
        }

        //Debug.Log(canWalk);
    }


    private void Start()
    {

        
       // print(speed);

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void AttackPlayer()
    {
        
    }


    private bool FieldOfViewCheck()
    {
        Vector3 enemyPosition = transform.position;
        Vector3 toPlayer = target.position - enemyPosition;

        if (toPlayer.magnitude <= radius)
        {
           // Debug.Log("WithinRange");
            if (Vector2.Dot(toPlayer.normalized, transform.up) > Mathf.Cos(angle * 0.5f * Mathf.Deg2Rad))
            {


               // Debug.Log("WithinAngle");
                if (!Physics2D.Raycast(transform.position, toPlayer.normalized, Vector2.Distance(transform.position, target.position), obstructMask))
                {
                    //Debug.Log("NoObstructions");
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (false);
            }

        }
        else
        {
            return (false);
        }
    }

}
