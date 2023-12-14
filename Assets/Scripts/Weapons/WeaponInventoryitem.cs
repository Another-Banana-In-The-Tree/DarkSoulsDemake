using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Items/Hand Item")]
public class WeaponInventoryitem : InventoryItem//, WeaponBase

  
{

   
    //[SerializeField] private WeaponBase storedWeapon;
    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)
    {
        playerEquipment.AssignWeaponItem(this);
        Debug.Log("Click");
    }

    
}
