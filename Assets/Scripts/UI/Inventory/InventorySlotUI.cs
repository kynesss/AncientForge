using InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] private Image itemIcon;
        [SerializeField] private TextMeshProUGUI quantityText;

        public void SetItem(InventorySlot slot)
        {
            itemIcon.sprite = slot.Item.Icon;
            quantityText.text = slot.Quantity > 1 ? $"{slot.Quantity}" : "";
        }
    }
}