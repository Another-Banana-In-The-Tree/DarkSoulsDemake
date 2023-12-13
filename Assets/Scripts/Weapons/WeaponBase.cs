using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private float heavyDelay;
    [SerializeField] private float lightDelay;

    

    [SerializeField] private float attackRange;
    private bool usingTwoHands;
    [SerializeField] private float attackPower;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float ATK;
    private float strength;
    Vector2 facingDirection;
    public void Attack(Vector2 dir, bool isLight,float str, bool isTwoHanded)
    {
        facingDirection = dir;
        strength = str;
        usingTwoHands = isTwoHanded;

        if (isLight)
        {
            LightAttack();
        }
        else
        {
            HeavyAttack();
        }
    }
    
    private IEnumerator AttackChargeUp(float chargeDelay, float animTime)
    {
       // Debug.Log("charge started");
       
        yield return new WaitForSeconds(chargeDelay);
       // Debug.Log("charge ended");
        StartCoroutine(AttackCoolDown(animTime));
    }
    private IEnumerator AttackCoolDown(float animTime)
    {
       // Debug.Log("cooldown started");
        PerformAttack();
        yield return new WaitForSeconds(animTime);
        //Debug.Log("cooldown ended");
        player.AttackSwitch();
    }
    private void LightAttack()
    {

        player.AttackSwitch();
       Debug.Log("light attack");
        if (usingTwoHands == true)
        {
            ATK = attackPower + attackPower * 1.2f * ((strength * 2)/99);
        }
        else
        {
            ATK = attackPower + attackPower * 1.2f * ((strength) / 99);
        }

       // ATK = ATK * 1.2f;
        StartCoroutine(AttackChargeUp(0.1f, lightDelay));

    }

    private void HeavyAttack()
    {
        
        player.AttackSwitch();
       Debug.Log("heavy attack");
        if (usingTwoHands == true)
        {
            ATK = attackPower + attackPower * 1.5f * ((strength * 2) / 99);
        }
        else
        {
            ATK = attackPower + attackPower * 1.5f * ((strength) / 99);
        }


       // ATK = ATK * 1.5f;

        StartCoroutine(AttackChargeUp(0.3f, heavyDelay));
    }
    private void PerformAttack()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(gameObject.transform.position, facingDirection, attackRange);
        Debug.DrawRay(gameObject.transform.position, facingDirection * attackRange, Color.red, lightDelay);

        if (hit.collider != null)
        {
            IDamageable target = hit.collider.gameObject.GetComponent<IDamageable>();
            if(target != null)
            {
                target.TakeDamage(ATK);
            }
           // Debug.Log("hit something");
            if (hit.collider.gameObject.layer == enemyLayer)
            {
               // Debug.Log("layer worked");
                Debug.Log(ATK.ToString());
            }
        }

        //ATK = 0;
        //CalculateDamage(mv, enemyDef);
    }
}
