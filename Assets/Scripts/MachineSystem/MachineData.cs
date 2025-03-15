using System.Collections.Generic;
using UnityEngine;

namespace MachineSystem
{
    [CreateAssetMenu(fileName = "Machine", menuName = "Machines/Machine")]
    public class MachineData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public float ProcessTime { get; private set; } = 3f;
        [field: SerializeField] public float SuccessChance { get; private set; } = 1.0f;
        [field: SerializeField] public List<MachineRecipe> Recipes { get; private set; }
    }
}