using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    
    [SerializeField] private Player player;

    /* [SerializeField] private float heavyDelay;
     [SerializeField] private float lightDelay;



     [SerializeField] private float attackRange;

     [SerializeField] private float attackPower;
     [SerializeField] private LayerMask enemyLayer;
     [SerializeField] private float ATK;*/
    [SerializeField] public float ATK;
    private bool usingTwoHands;
    private float strength;
    Vector2 facingDirection;
    [SerializeField] private LayerMask enemyLayer;

    private WeaponInventoryitem weapon;


    public void SetCurrentWeapon(WeaponInventoryitem newWeapon)
    {
        weapon = newWeapon;
    }

    

    public void AttackAction(Vector2 dir, bool isLight, float str, bool isTwoHanded)
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

    public void SetPlayer(Player newPlayer)
    {
        player = newPlayer;
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
            ATK = weapon.attackPower + weapon.attackPower * 1.2f * ((strength * 2) / 99);
        }
        else
        {
            ATK = weapon.attackPower + weapon.attackPower * 1.2f * ((strength) / 99);
        }

        // ATK = ATK * 1.2f;
        StartCoroutine(AttackChargeUp(0.1f, weapon.lightDelay));

    }

    private void HeavyAttack()
    {

        player.AttackSwitch();
        Debug.Log("heavy attack");
        if (usingTwoHands == true)
        {
            ATK = weapon.attackPower + weapon.attackPower * 1.5f * ((strength * 2) / 99);
        }
        else
        {
            ATK = weapon.attackPower + weapon.attackPower * 1.5f * ((strength) / 99);
        }


        // ATK = ATK * 1.5f;

        StartCoroutine(AttackChargeUp(0.3f, weapon.heavyDelay));
    }
    private void PerformAttack()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(gameObject.transform.position, facingDirection, weapon.attackRange, enemyLayer);
        Debug.DrawRay(gameObject.transform.position, facingDirection * weapon.attackRange, Color.red, weapon.lightDelay);

        if (hit.collider != null)
        {
            Debug.Log("hit something");
            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.TryGetComponent(out IDamageable hitObject))
            {
                Debug.Log("take Damage");
                hitObject.TakeDamage(ATK);
            }
            
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


