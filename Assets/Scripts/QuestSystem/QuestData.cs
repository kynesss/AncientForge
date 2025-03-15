using UnityEngine;
using MachineSystem;

namespace QuestSystem
{
    [CreateAssetMenu(fileName = "NewQuest", menuName = "Quests/Quest")]
    public class QuestData : ScriptableObject
    {
        [field: SerializeField] public string QuestName { get; private set; }
        [field: SerializeField] public QuestRequirement RequiredItems { get; private set; }
        [field: SerializeField] public MachineData MachineToUnlock { get; private set; }
    }
}