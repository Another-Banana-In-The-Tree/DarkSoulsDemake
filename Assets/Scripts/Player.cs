using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //STATS
    [field: Header("Stats")]
    [SerializeField] private float healthMax;
    [SerializeField] private float healthTotal;
    [SerializeField] private float staminaMax;
    [SerializeField] private float staminaTotal;
    [SerializeField] private float vitality;
    [SerializeField] private float attunement;
    [SerializeField] private float endurance;
    [SerializeField] private float strength;
    [SerializeField] private float dexterity;
    [SerializeField] private float resistance;
    [SerializeField] private float intelligence;
    [SerializeField] private float faith;
    [SerializeField] private float humanity;



    //MOVEMENT
    Rigidbody2D rb;
    Vector2 _moveDir;
    [field: Header("Speed")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _dodgeSpeed;
    [SerializeField] private float encumberence;
    //INPUT CHECKS
    private bool isDodging;
    private bool isAttacking;
    private bool iFrameActive;
    //TIMERS
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

    public void TakeDamage(float damage)
    {
        healthTotal -= damage;
    }

    public void ReduceStamina(float usedStamina)
    {
        staminaTotal -= usedStamina;
    }
}
