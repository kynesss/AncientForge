using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(fileName = "BonusItem", menuName = "Inventory/BonusItem")]
    public class BonusItemData : ItemData
    {
        [field: SerializeField] public float BonusValue { get; private set; }
    }
}