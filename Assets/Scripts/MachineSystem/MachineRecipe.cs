using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

namespace MachineSystem
{
    [System.Serializable]
    public class MachineRecipe
    {
        [field: SerializeField] public List<ItemData> InputItems { get; private set; }
        [field: SerializeField] public ItemData OutputItem { get; private set; }
    }
}