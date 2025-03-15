using Core;
using InventorySystem;
using UnityEngine;

namespace Bonuses
{
    public class BonusTracker : MonoBehaviour, IService
    {
        [SerializeField] private BonusItemData timeAmulet;
        [SerializeField] private BonusItemData luckyCharm;
        
        public float GetProcessTimeBonus()
        {
            return Services.Inventory.HasItem(timeAmulet) ? timeAmulet.BonusValue : 0f;
        }
        
        public float GetSuccessChanceBonus()
        {
            return Services.Inventory.HasItem(luckyCharm) ? luckyCharm.BonusValue : 0f;
        }
    }
}