using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 _moveDir;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _dodgeSpeed;
    [SerializeField] float encumberence;

    void Start()
    {
        Controls.Init(this);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //rb.velocity = _moveDir * _moveSpeed;

        rb.AddForce(_moveDir * _moveSpeed * encumberence , ForceMode2D.Impulse);
    }

    public void SetMovmentDirection(Vector2 dir)
    {
        _moveDir = dir.normalized;
    }
    public void Dodge()
    {
        Debug.Log("Dodging...");
        rb.AddForce(_moveDir * _dodgeSpeed, ForceMode2D.Impulse);
    }
}
