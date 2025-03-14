using UnityEngine;

namespace MachineSystem
{
    [CreateAssetMenu(fileName = "Machine", menuName = "Machines/Machine")]
    public class MachineData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public MachineType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}