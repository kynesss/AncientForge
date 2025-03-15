using System.Collections.Generic;
using Core;
using QuestSystem.Events;
using UnityEngine;

namespace QuestSystem
{
    public class QuestManager : MonoBehaviour, IService
    {
        [SerializeField] private List<QuestData> questDatas;
        
        private readonly List<Quest> _activeQuests = new();

        public event QuestCompletedEvent QuestCompleted;
        
        private void Start()
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
                _activeQuests.Add(new Quest(questData));
            }
        }

        private void UpdateQuests()
        {
            for (var i = _activeQuests.Count - 1; i >= 0; i--)
            {
                var quest = _activeQuests[i];
                quest.Update();

                if (quest.IsCompleted)
                {
                    QuestCompleted?.Invoke(quest.Data);
                    _activeQuests.Remove(quest);
                }
            }
        }

        private void Inventory_OnInventoryChanged()
        {
            UpdateQuests();
        }
    }
}