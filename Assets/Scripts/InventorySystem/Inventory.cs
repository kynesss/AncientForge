using System.Collections.Generic;
using System.Linq;
using InventorySystem.Events;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        public List<InventorySlot> Items { get; } =  new();

        public event InventoryChangedEvent InventoryChanged;

        public void AddItem(ItemData item, int quantity)
        {
            var slot = Items.FirstOrDefault(x => x.Item == item);

            if (slot != null)
            {
                slot.Quantity += quantity;
            }
            else
            {
                Items.Add(new InventorySlot(item, quantity));
            }
            
            InventoryChanged?.Invoke();
        }

        public void RemoveItem(ItemData item, int quantity)
        {
            var slot = Items.FirstOrDefault(x => x.Item == item);

            if (slot != null)
            {
                slot.Quantity -= quantity;
                
                if (slot.Quantity <= 0)
                    Items.Remove(slot);
            }
            
            InventoryChanged?.Invoke();
        }

        public bool HasItem(ItemData item)
        {
            return Items.Any(x => x.Item == item);
        }
    }
}