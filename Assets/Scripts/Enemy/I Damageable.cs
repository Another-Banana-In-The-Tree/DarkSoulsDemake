using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public float Health { get; set; }
    public float defenceV { get; set; }
    public void TakeDamage(float atk)
    {
        Debug.Log("attack " + atk);
        float damage = 0;
        /* if (atk <= ((1f / 8f) * defenceV))
         {
             damage = atk * 0.1f;
             //Debug.Log("less than an eigth");
         }
         else if (atk <= defenceV)
         {
             damage = (atk * ((19.2f / 49f) * (Mathf.Pow((atk / defenceV) - 0.125f, 2)))) + 0.1f;
             //Debug.Log("less than defence");
         }
         else if(atk <= (2.5f * defenceV))
         {
             damage = (atk * ((-0.4f / 3f) * (Mathf.Pow((atk / defenceV) - 2.5f, 2)))) + 0.7f;
             //Debug.Log("less than 2.5 tiems defence");
         }
          else if(atk <= (8f * defenceV))
         {
             damage = (atk * ((-0.8f / 121f) * (Mathf.Pow((atk / defenceV) - 8f, 2)))) + 0.9f;
            // Debug.Log("less than eight times defence");
         }
          else if(atk >= ( 8f * defenceV))
         {
             damage = atk * 0.9f;
             Debug.Log("greater than 8 times");
         }*/

        if (atk >= defenceV)
        {
            Debug.Log("more");
            damage = ((atk * 1.5f - defenceV)) /2.5f;
        }
        else
        {
            Debug.Log("less");
            damage = ((atk * atk) / defenceV)/3f;
        }

        Debug.Log("damge: " + damage);
    }
}
