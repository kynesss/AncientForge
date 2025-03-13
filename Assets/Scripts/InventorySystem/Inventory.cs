using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        private readonly List<InventorySlot> _items = new();

        public void AddItem(ItemData item, int quantity)
        {
            var slot = _items.FirstOrDefault(x => x.Item == item);

            if (slot != null)
            {
                slot.Quantity += quantity;
            }
            else
            {
                _items.Add(new InventorySlot(item, quantity));
            }
        }

        public void RemoveItem(ItemData item, int quantity)
        {
            var slot = _items.FirstOrDefault(x => x.Item == item);

            if (slot != null)
            {
                slot.Quantity -= quantity;
                
                if (slot.Quantity <= 0)
                    _items.Remove(slot);
            }
        }

        public bool HasItem(ItemData item)
        {
            return _items.Any(x => x.Item == item);
        }
    }
}