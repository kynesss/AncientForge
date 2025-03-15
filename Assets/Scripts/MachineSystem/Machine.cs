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
        [SerializeField] private MachineData data;
        [SerializeField] private Inventory inventory;

        private bool _isProcessing;

        public string GetMachineName()
        {
            return data.Name;
        }

        public List<MachineRecipe> GetRecipes()
        {
            return data.Recipes;
        }

        public async UniTask StartProcessing(MachineRecipe recipe)
        {
            if (_isProcessing) 
                return;
            
            _isProcessing = true;

            Debug.Log($"{data.Name} started processing {recipe.OutputItem.Name}...");
            await UniTask.Delay(TimeSpan.FromSeconds(data.ProcessTime));

            var success = Random.value <= data.SuccessChance;
            
            if (success)
            {
                inventory.AddItem(recipe.OutputItem, 1);
                Debug.Log($"Successfully crafted {recipe.OutputItem.Name}!");
            }
            else
            {
                Debug.Log($"Processing failed. Ingredients lost.");
            }

            _isProcessing = false;
        }
    }
}