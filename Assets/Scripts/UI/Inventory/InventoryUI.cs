using Core;
using UnityEngine;
using Utils;

namespace UI.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySlotUI slotPrefab;
        [SerializeField] private Transform grid;

        private void Awake()
        {
            grid.DestroyAllChildren();
        }

        private void OnEnable()
        {
            Services.Inventory.InventoryChanged += OnInventoryChanged;
        }

        private void OnDisable()
        {
            Services.Inventory.InventoryChanged -= OnInventoryChanged;
        }

        private void UpdateUI()
        {
            grid.DestroyAllChildren();
            
            foreach (var inventorySlot in Services.Inventory.Items)
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