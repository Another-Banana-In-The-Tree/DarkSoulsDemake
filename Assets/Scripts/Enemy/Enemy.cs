using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

   [field:SerializeField] public float Health { get; set; }
    [field: SerializeField] public float defenceV { get; set; }

    [SerializeField] private GameObject dropPrefab;


    public void Die()
    {
        Instantiate(dropPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
