using TMPro;
using UnityEngine;
using QuestSystem;

namespace UI.Quests
{
    public class QuestEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI questText;
        
        public void Display(Quest quest)
        {
            questText.text = $"{quest.Data.QuestName}: {quest.CurrentAmount}/{quest.RequiredAmount}";
        }
    }
}