using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public float Health { get; set; }
    public float defenceV { get; set; }
    public void TakeDamage(float atk)
    {
       // Debug.Log("attack " + atk);
        float damage = 0;
       

        if (atk >= defenceV)
        {
            //Debug.Log("more");
            damage = ((atk * 1.5f - defenceV)) /2.5f;
        }
        else
        {
            //Debug.Log("less");
            damage = ((atk * atk) / defenceV)/3f;
        }

       // Debug.Log(damage);
        Health -= damage;

        if(Health <= 0) 
        {
            Die();
        }
    }
    public void Die();
    
    
}
