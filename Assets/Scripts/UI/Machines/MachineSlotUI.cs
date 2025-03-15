using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using InventorySystem;
using System;
using UI.Inventory;

namespace UI.Machines
{
    public class MachineSlotUI : MonoBehaviour, IDropHandler
    {
        [SerializeField] private Image itemIcon;
        [SerializeField] private Color transparentColor = new(1, 1, 1, 0.5f);
        
        public ItemData RequiredItem { get; private set; }
        public ItemData InsertedItem { get; private set; }
        public bool IsFilled { get; private set; }

        public event Action<MachineSlotUI, bool> OnItemChanged;

        public void SetRequiredItem(ItemData item)
        {
            RequiredItem = item;
            itemIcon.sprite = item.Icon;
            itemIcon.color = transparentColor;
            IsFilled = false;
            InsertedItem = null;
        }

        public void ClearSlot()
        {
            if (IsFilled)
            {
                IsFilled = false;
                InsertedItem = null;
                itemIcon.color = transparentColor;
                OnItemChanged?.Invoke(this, false);
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            var draggedItem = eventData.pointerDrag.GetComponent<InventorySlotUI>();
            var droppedItem = draggedItem.Item;

            if (droppedItem == RequiredItem)
            {
                IsFilled = true;
                InsertedItem = droppedItem;
                itemIcon.color = Color.white;

                Debug.Log($"{droppedItem.Name} placed in slot.");
                OnItemChanged?.Invoke(this, true);
            }
            else
            {
                Debug.Log("This item is not required for this recipe.");
                OnItemChanged?.Invoke(this, false);
            }
        }
    }
}