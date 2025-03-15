using Core;
using UnityEngine;
using QuestSystem;
using Utils;

namespace UI.Quests
{
    public class QuestUI : MonoBehaviour
    {
        [SerializeField] private Transform questContainer; 
        [SerializeField] private QuestEntryUI questEntryPrefab; 

        private void OnEnable()
        {
            Services.QuestManager.QuestUpdated += OnQuestUpdated;
            Services.QuestManager.QuestCompleted += OnQuestCompleted;
        }

        private void OnDisable()
        {
            Services.QuestManager.QuestUpdated -= OnQuestUpdated;
            Services.QuestManager.QuestCompleted -= OnQuestCompleted;
        }

        private void Start()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            questContainer.DestroyAllChildren();
            
            foreach (var quest in Services.QuestManager.ActiveQuests)
            {
                var questEntry = Instantiate(questEntryPrefab, questContainer);
                questEntry.Display(quest);
            }
        }

        private void OnQuestUpdated()
        {
            UpdateUI();   
        }

        private void OnQuestCompleted(QuestData questData)
        {
            UpdateUI();
        }
    }
}