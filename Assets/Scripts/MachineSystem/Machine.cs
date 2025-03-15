using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using InventorySystem;
using Random = UnityEngine.Random;

namespace MachineSystem
{
    public class Machine : MonoBehaviour
    {
        [field: SerializeField] public MachineData Data { get; private set; }
        
        [SerializeField] private Inventory inventory;
        public bool IsProcessing { get; private set; }

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
            await UniTask.Delay(TimeSpan.FromSeconds(Data.ProcessTime));

            var success = Random.value <= Data.SuccessChance;
            
            if (success)
            {
                inventory.AddItem(recipe.OutputItem, 1);
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