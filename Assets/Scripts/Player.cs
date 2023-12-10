using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 _moveDir;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _dodgeSpeed;

    void Start()
    {
        Controls.Init(this);
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = _moveDir * _moveSpeed;
    }

    public void SetMovmentDirection(Vector2 dir)
    {
        _moveDir = dir;
    }
    public void Dodge()
    {
        Debug.Log("Dodging...");
        rb.AddForce(_moveDir * _dodgeSpeed);
    }
}
