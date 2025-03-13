using System;
using UnityEngine;
using Utils;

namespace UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySystem.Inventory inventory;
        [SerializeField] private InventorySlotUI slotPrefab;
        [SerializeField] private Transform grid;

        private void Awake()
        {
            grid.DestroyAllChildren();
        }

        private void OnEnable()
        {
            inventory.InventoryChanged += OnInventoryChanged;
        }

        private void OnDisable()
        {
            inventory.InventoryChanged -= OnInventoryChanged;
        }

        private void UpdateUI()
        {
            grid.DestroyAllChildren();
            
            foreach (var inventorySlot in inventory.Items)
            {
                var slotEntry = Instantiate(slotPrefab, grid);
                slotEntry.SetItem(inventorySlot);
            }
        }

        private void OnInventoryChanged()
        {
            UpdateUI();
        }
    }
}