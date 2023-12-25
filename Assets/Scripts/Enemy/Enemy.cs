using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public abstract class Enemy : MonoBehaviour, IDamageable
{

   [field:SerializeField] public float Health { get; set; }
    [field: SerializeField] public float defenceV { get; set; }

    [SerializeField]  protected GameObject dropPrefab;

    [SerializeField] protected float speed;
    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected float angleMod;

    [SerializeField] protected float nextWayPointDistance;

    [SerializeField] protected Transform target;

    protected Path path;
    protected int currentWayPoint;
    protected bool reachedEndOfPath = false;
    protected Seeker seeker;
    protected Rigidbody2D rb;
    protected bool canWalk;


    //MOVEMENT STUFF

    private Vector2 direction;
    private Vector2 force;
    private float distance;

    protected void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }

        //Move();
        
    }
    
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 1;
        }
    }

    protected void Move()
    {

        if (!canWalk) return;
        Debug.Log("can walk");

        





        if (path == null) return;
        Debug.Log("path found");
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Debug.Log("Update: " + currentWayPoint);

        force = direction * speed;

        distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        rb.AddForce(force, ForceMode2D.Impulse);



       // Debug.Log("Next way point: " + nextWayPointDistance);
        if (distance < nextWayPointDistance)
        {
            Debug.Log("next point");
            currentWayPoint++;

        }
    }

    private void Update()
    {
        if (!canWalk) return;
        //swap (Vector2)path.vectorPath[currentWayPoint] with target.position for less snappy and smoother rotation aimed at the player rather than the path ahead
        Vector3 vectorToTarget = (Vector3)path.vectorPath[currentWayPoint] - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - angleMod;
        Quaternion Q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, Q, Time.deltaTime * rotationSpeed);
        /*
                //Debug.Log("test");
                if (!canWalk) return;

                // Debug.Log("can walk");

                Vector3 vectorToTarget = target.position - transform.position;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - angleMod;
                Quaternion Q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, Q, Time.deltaTime * rotationSpeed);





                if (path == null) return;
                Debug.Log("path found");
                if (currentWayPoint >= path.vectorPath.Count)
                {
                    reachedEndOfPath = true;
                    return;
                }
                else
                {
                    reachedEndOfPath = false;
                }

                Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
                Debug.Log("Update: " + currentWayPoint);

                Vector2 force = direction * speed * Time.deltaTime;

                float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

                rb.AddForce(force, ForceMode2D.Impulse);


                if (distance < nextWayPointDistance)
                {
                    currentWayPoint++;

                }*/

    }

    public void Die()
    {
        Instantiate(dropPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected virtual void AttackPlayer() {
    }

}
