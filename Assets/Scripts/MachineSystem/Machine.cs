using System;
using System.Collections.Generic;
using Core;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MachineSystem
{
    public class Machine : MonoBehaviour
    {
        [field: SerializeField] public MachineData Data { get; private set; }
        public bool IsProcessing { get; private set; }
        public float ProcessTime => Mathf.Max(1f, Data.ProcessTime - ProcessTimeBonus);
        private float ProcessTimeBonus => Services.Bonus.GetProcessTimeBonus();
        
        public string GetMachineName()
        {
            return Data.Name;
        }

        public List<MachineRecipe> GetRecipes()
        {
            return Data.Recipes;
        }

        public async UniTask StartProcessing(MachineRecipe recipe)
        {
            if (IsProcessing) 
                return;
            
            IsProcessing = true;

            Debug.Log($"{Data.Name} started processing {recipe.OutputItem.Name}...");
            await UniTask.Delay(TimeSpan.FromSeconds(ProcessTime));

            var success = Random.value <= (Data.SuccessChance + Services.Bonus.GetSuccessChanceBonus());
            
            if (success)
            {
                foreach (var inputItem in recipe.InputItems)
                {
                    Services.Inventory.RemoveItem(inputItem, 1);
                }
                
                Services.Inventory.AddItem(recipe.OutputItem, 1);
                Debug.Log($"Successfully crafted {recipe.OutputItem.Name}!");
            }
            else
            {
                Debug.Log($"Processing failed. Ingredients lost.");
            }
            
            IsProcessing = false;
        }
    }
}