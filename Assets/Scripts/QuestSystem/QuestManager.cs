using System.Collections.Generic;
using Core;
using QuestSystem.Events;
using UnityEngine;

namespace QuestSystem
{
    public class QuestManager : MonoBehaviour, IService
    {
        [SerializeField] private List<QuestData> questDatas;
        public List<Quest> ActiveQuests { get; } = new();
        public event QuestCompletedEvent QuestCompleted;
        public event QuestUpdatedEvent QuestUpdated;
        
        private void Awake()
        {
            InitializeQuests();
        }

        private void OnEnable()
        {
            Services.Inventory.InventoryChanged += Inventory_OnInventoryChanged;
        }

        private void OnDisable()
        {
            Services.Inventory.InventoryChanged -= Inventory_OnInventoryChanged;
        }
        
        private void InitializeQuests()
        {
            foreach (var questData in questDatas)
            {
                ActiveQuests.Add(new Quest(questData));
            }
        }

        [ContextMenu("Update")]
        private void UpdateQuests()
        {
            for (var i = ActiveQuests.Count - 1; i >= 0; i--)
            {
                var quest = ActiveQuests[i];
                quest.Update();

                if (quest.IsCompleted)
                {
                    QuestCompleted?.Invoke(quest.Data);
                    ActiveQuests.Remove(quest);
                }
            }
            
            QuestUpdated?.Invoke();
        }

        private void Inventory_OnInventoryChanged()
        {
            UpdateQuests();
        }
    }
}