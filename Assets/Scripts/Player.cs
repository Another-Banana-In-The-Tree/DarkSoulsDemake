using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 _moveDir;
    [field: Header("Speed")]
    [SerializeField] float _moveSpeed;
    [SerializeField] float _dodgeSpeed;
    [SerializeField] float encumberence;
    private bool isDodging;
    private bool isAttacking;
    private bool iFrameActive;
    [field: Header("Delays")]
    [SerializeField] private float dodgeDelay;
    [SerializeField] private float dodgeIFrames;
    [SerializeField] private float heavyDelay;
    [SerializeField] private float lightDelay;
    [SerializeField] private float itemDelay;
   // [SerializeField] private float 


    private WaitForSeconds dodgeWait;
    private WaitForSeconds dodgeInvulnerable;
    private WaitForSeconds lightAttackDelay;
    private WaitForSeconds heavyAttackDelay;
    private WaitForSeconds itemUseDelay;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Controls.Init(this);
        dodgeWait = new WaitForSeconds(dodgeDelay);
        dodgeInvulnerable = new WaitForSeconds(dodgeIFrames);
        lightAttackDelay = new WaitForSeconds(lightDelay);
        heavyAttackDelay = new WaitForSeconds(heavyDelay);
        itemUseDelay = new WaitForSeconds(itemDelay);
            
        
    }

    void FixedUpdate()
    {
        //rb.velocity = _moveDir * _moveSpeed;
        if (isDodging || isAttacking) return;
        rb.AddForce(_moveDir * _moveSpeed * encumberence , ForceMode2D.Impulse);
    }

    public void SetMovmentDirection(Vector2 dir)
    {
        _moveDir = dir.normalized;
    }
    public void Dodge()
    {
        Debug.Log("Dodging...");
        if (isDodging) return;
        StartCoroutine("DodgeCoolDown");
        rb.AddForce(_moveDir * _dodgeSpeed, ForceMode2D.Impulse);
    }

    private IEnumerator DodgeCoolDown()
    {
        isDodging = true;
        yield return dodgeWait;
        isDodging = false;


    }

    private IEnumerator AttackCoolDown(WaitForSeconds delay)
    {
        yield return delay;
    }
}
