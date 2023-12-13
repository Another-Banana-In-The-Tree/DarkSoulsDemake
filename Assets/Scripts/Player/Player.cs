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
    //[SerializeField] private float attunement;
    [SerializeField] private float endurance;
    [SerializeField] private float strength;
    [SerializeField] private float dexterity;
    //[SerializeField] private float resistance;
   // [SerializeField] private float intelligence;
   // [SerializeField] private float faith;
   // [SerializeField] private float humanity;



    //MOVEMENT
    Rigidbody2D rb;
    Vector2 _moveDir;
    Vector2 facingDirection;
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
    //[SerializeField] private float heavyDelay;
   // [SerializeField] private float lightDelay;
    [SerializeField] private float itemDelay;
   // [SerializeField] private float 


    private WaitForSeconds dodgeWait;
    private WaitForSeconds dodgeInvulnerable;

    
    /*****************************************
     * LIGHT ATTACK AND HEAVY ATTACK DELAYS SHOULD BECOME PROPERTIES OF THE WEAPONS 
     * 
     * 
     * 
     * 
   ******************************************/
    //private WaitForSeconds lightAttackDelay;
   // private WaitForSeconds heavyAttackDelay;
    private WaitForSeconds itemUseDelay;

    [field: Header("Combat")]
    [SerializeField] private WeaponBase weapon;

   // [SerializeField] private float attackRange;
    [SerializeField]private bool usingTwoHands;
   //[SerializeField] private float attackPower;
    private float unarmedDamage = 20;
    private bool leftHandFree;
    private bool righthandFree;
   // [SerializeField] private LayerMask enemyLayer;
   // [SerializeField]private float ATK;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        facingDirection = Vector2.up;
    }
    void Start()
    {
        Controls.Init(this);
        dodgeWait = new WaitForSeconds(dodgeDelay);
        dodgeInvulnerable = new WaitForSeconds(dodgeIFrames);
       // lightAttackDelay = new WaitForSeconds(lightDelay);
       // heavyAttackDelay = new WaitForSeconds(heavyDelay);
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
        if(_moveDir != Vector2.zero)
        {
           // Debug.Log(facingDirection);
            facingDirection = _moveDir;
        }
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
    

    public void TakeDamage(float damage)
    {
        healthTotal -= damage;
    }

    public void ReduceStamina(float usedStamina)
    {
        staminaTotal -= usedStamina;
    }

    private void SetMaxHealth()
    {
        healthMax = 385 + (15 * (vitality));
    }
    private void SetMaxStamina()
    {
        staminaMax = 80 + (8 * (endurance));
    }


    public void LightAttack()
    {
        weapon.Attack(facingDirection, true, strength, usingTwoHands);


    }

    public void HeavyAttack()
    {
        weapon.Attack(facingDirection, false, strength, usingTwoHands);

    }


    public void AttackSwitch()
    {
        isAttacking = !isAttacking;
    }
    
}
