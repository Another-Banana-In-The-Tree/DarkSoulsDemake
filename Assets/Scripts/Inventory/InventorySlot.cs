using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemCountText;
    [SerializeField] private Button slotButton;


    public void InitSlotVisualisation(Sprite sprite, string itemName, int itemCount)
    {
        itemImage.sprite = sprite;
        itemNameText.text = itemName;
        UpdateSlotCount(itemCount);
    }

    public void UpdateSlotCount(int itemcount)
    {
        itemCountText.text = itemcount.ToString();
    }

    public void AssingSlotButtonCallback(System.Action onClickCallback)
    {
        slotButton.onClick.AddListener(() => onClickCallback());
    }


}
