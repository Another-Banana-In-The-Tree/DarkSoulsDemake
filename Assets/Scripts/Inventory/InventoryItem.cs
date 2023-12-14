using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu (menuName = "Scriptable Objects/Inventory System/Item ")]
public abstract class InventoryItem : ScriptableObject
{
    
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string itemName;
    [SerializeField] Vector3 itemLocalPos;
    [SerializeField] Vector3 itemLocalRot;


    [field: Header("Weapon Stuff")]

    [SerializeField] public float heavyDelay;
    [SerializeField] public float lightDelay;



    [SerializeField] public float attackRange;
    //private bool usingTwoHands;
    [SerializeField] public float attackPower;
    [SerializeField] public LayerMask enemyLayer;

    public GameObject GetPrefab()
    {
        return itemPrefab;
    }
    public Sprite GetSprite()
    {
        return itemSprite;
    }

    public string GetName()
    {
        return itemName;
    }

    public Vector3 GetLocalPos()
    {
        return itemLocalPos;
    }

    public Quaternion GetLocalRot()
    {
        return Quaternion.Euler(itemLocalRot); 
    }

    public abstract void AssignItemToPlayer(PlayerEquipmentController playerEquipment);
    

    
}
