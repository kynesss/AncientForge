using UnityEngine;
using Random = UnityEngine.Random;

namespace InventorySystem
{
    public class InventoryInitializer : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;

        [Header("Resources")]
        [SerializeField] private StartItem[] startItems;

        [Header("Bonus")]
        [SerializeField] private ItemData[] bonusItems;
        [SerializeField] private float bonusChance = 0.25f;

        private void Start()
        {
            AddResources();
            AddBonuses();
        }

        private void AddResources()
        {
            foreach (var startItem in startItems)
            {
                var quantity = Random.Range(startItem.MinQuantity, startItem.MaxQuantity + 1);
                inventory.AddItem(startItem.Item, quantity);
                
                Debug.Log($"Added {quantity}x {startItem.Item.Name} to inventory");
            }
        }

        private void AddBonuses()
        {
            foreach (var bonusItem in bonusItems)
            {
                if (Random.value < bonusChance)
                {
                    inventory.AddItem(bonusItem, 1);
                    Debug.Log($"Bonus item added: {bonusItem.Name}");
                }
            }
        }
    }
}