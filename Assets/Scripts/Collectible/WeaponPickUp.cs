using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour, Collectible
{

    [SerializeField] private WeaponInventoryitem heldWeapon;
    [SerializeField] private int amount;
    private SpriteRenderer  spriteRender;
    // Start is called before the first frame update
    private void OnEnable()
    {
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        spriteRender.sprite = heldWeapon.GetSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect(GameObject playerObj)
    {
        playerObj.GetComponent<PlayerEquipmentController>().AddItem(heldWeapon, amount);
        Destroy(gameObject);
    }
}
