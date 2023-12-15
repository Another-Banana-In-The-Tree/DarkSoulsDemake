using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform inventoryParent;

    [SerializeField] private Transform HelmetAnchor;
    [SerializeField] private Transform leftHandAnchor;
    [SerializeField] private Transform rightHandAnchor;
    [SerializeField] private Transform armourAnchor;

    private GameObject currentWeapon;

    private Player player;

    private void Start()
    {
        inventory.InitInventory(this);
        //inventory.OpenInventoryUI();
    }

    public void InitPlayer(Player playerObj)
    {
        player = playerObj;
    }
    public void Open()
    {
        inventory.OpenInventoryUI();
    }

    public void Close()
    {
        inventory.CloseInventoryUI();
    }

    public void AssignWeaponItem(WeaponInventoryitem item)
    {
        DestroyIfNotNull(currentWeapon);
        currentWeapon = CreateNewItemInstance(item, rightHandAnchor);
        player.EquipWeapon(item);
    }



    public void AssignGloveItem()
    {

    }

    public void AssignHelmetItem()
    {

    }

    public void AssignChestItem()
    {

    }

    public void AssignPantItem()
    {

    }
    public void AssignShoeItem()
    {

    }



    public Transform getUIParent()
    {
        return inventoryParent;
    }

    

    private void DestroyIfNotNull(GameObject obj)
    {
        if (obj)
        {
            Destroy(obj);
        }
    }

    private GameObject CreateNewItemInstance(WeaponInventoryitem item, Transform anchor)
    {
        var itemInstance = Instantiate(item.GetPrefab(), anchor);
        return itemInstance;
    }

    public void AddItem(InventoryItem item, int amount)
    {
        inventory.AddItem(item, amount);
    }
}
