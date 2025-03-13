using System;
using UnityEngine;

namespace InventorySystem
{
    [Serializable]
    public struct StartItem
    {
        [field: SerializeField] public ItemData Item { get; private set; }
        [field: SerializeField] public int MinQuantity { get; private set; }
        [field: SerializeField] public int MaxQuantity { get; private set; }
    }
}