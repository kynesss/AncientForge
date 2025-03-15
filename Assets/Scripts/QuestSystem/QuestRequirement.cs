using System;
using InventorySystem;
using UnityEngine;

namespace QuestSystem
{
    [Serializable]
    public class QuestRequirement
    {
        [field: SerializeField] public ItemData Item { get; private set; }
        [field: SerializeField] public int Quantity { get; private set; }
    }
}