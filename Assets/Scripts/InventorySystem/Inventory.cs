using System.Collections.Generic;
using System.Linq;
using Core;
using InventorySystem.Events;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour, IService
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
        
        public int GetItemQuantity(ItemData item)
        {
            var slot = Items.FirstOrDefault(x => x.Item == item);
            return slot?.Quantity ?? 0;
        }

        public bool HasItem(ItemData item)
        {
            return Items.Any(x => x.Item);
        }
    }
}