using Core;
using UnityEngine;

namespace QuestSystem
{
    public class Quest
    {
        public QuestData Data { get; }
        public int CurrentAmount { get; private set; }
        public int RequiredAmount => Data.RequiredItems.Quantity;
        public bool IsCompleted => CurrentAmount == RequiredAmount;
        
        public Quest(QuestData data)
        {
            Data = data;
        }

        public void Update()
        {
            var item = Data.RequiredItems.Item;
            CurrentAmount = Services.Inventory.GetItemQuantity(item);
            
            Debug.Log($"Quest: {Data.QuestName} {CurrentAmount} / {RequiredAmount}");
        }
    }
}