using System;
using Bonuses;
using InventorySystem;
using QuestSystem;
using UnityEngine;

namespace Core
{
    public static class Services
    {
        private static Inventory _inventory;
        public static Inventory Inventory => _inventory ??= FindOrThrow<Inventory>();
        
        private static QuestManager _questManager;
        public static QuestManager QuestManager => _questManager ??= FindOrThrow<QuestManager>();
        
        private static BonusTracker _bonus;
        public static BonusTracker Bonus => _bonus ??= FindOrThrow<BonusTracker>();
        
        private static T FindOrThrow<T>() where T : MonoBehaviour, IService
        {
            var service = UnityEngine.Object.FindObjectOfType<T>();
            if (service == null)
            {
                throw new Exception($"Could not find service of type {typeof(T)}");
            }

            return service;
        }
    }
}