using System.Collections.Generic;
using Core;
using MachineSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.Machines
{
    public class MachineForgeUI : MonoBehaviour
    {
        [SerializeField] private Transform slotContainer;
        [SerializeField] private Image outputPreview;
        [SerializeField] private MachineSlotUI slotPrefab;
        [SerializeField] private MachineProgressBarUI progressBar;

        [SerializeField] private Button forgeButton;
        [SerializeField] private Button previousButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button exitButton;
        
        [SerializeField] private TextMeshProUGUI machineTitle; 

        private readonly List<MachineSlotUI> _activeSlots = new();

        private List<MachineRecipe> _recipes;
        private MachineRecipe _currentRecipe;
        
        private Machine _currentMachine;
        private int _currentRecipeIndex;
        
        private void OnEnable()
        {
            previousButton.onClick.AddListener(PreviousButton_OnClick);
            nextButton.onClick.AddListener(NextButton_OnClick);
            exitButton.onClick.AddListener(ExitButton_OnClick);
            forgeButton.onClick.AddListener(ForgeButton_OnClick);
        }

        private void OnDisable()
        {
            previousButton.onClick.RemoveListener(PreviousButton_OnClick);
            nextButton.onClick.RemoveListener(NextButton_OnClick);
            exitButton.onClick.RemoveListener(ExitButton_OnClick);
            forgeButton.onClick.RemoveListener(ForgeButton_OnClick);
        }

        public void Open(Machine machine)
        {
            if (machine.IsProcessing)
                return;
            
            slotContainer.DestroyAllChildren();
            
            _currentMachine = machine;
            _recipes = machine.GetRecipes();
            _currentRecipeIndex = 0;
            _currentRecipe = _recipes[_currentRecipeIndex];
            
            machineTitle.text = machine.GetMachineName();
            ShowRecipe();
            gameObject.SetActive(true);
        }

        private void ShowRecipe()
        {
            ReturnItemsToInventory(); 
            ClearSlots(); 

            foreach (var item in _currentRecipe.InputItems)
            {
                var machineSlot = Instantiate(slotPrefab, slotContainer);
                machineSlot.SetRequiredItem(item);
                machineSlot.OnItemChanged += MachineSlot_OnItemChanged;
        
                _activeSlots.Add(machineSlot);
            }

            outputPreview.sprite = _currentRecipe.OutputItem.Icon;
            forgeButton.interactable = false; 
        }


        private void MachineSlot_OnItemChanged(MachineSlotUI slot, bool isCorrect)
        {
            if (!isCorrect && slot.InsertedItem != null)
            {
                Debug.Log("Returning invalid item to inventory.");
                Services.Inventory.AddItem(slot.InsertedItem, 1);
                slot.ClearSlot();
            }

            CheckIfReadyToForge();
        }
        
        private void CheckIfReadyToForge()
        {
            var allFilled = _activeSlots.TrueForAll(slot => slot.IsFilled);
            forgeButton.interactable = allFilled;
        }

        private void ClearSlots()
        {
            foreach (var slot in _activeSlots)
            {
                slot.OnItemChanged -= MachineSlot_OnItemChanged;
                Destroy(slot.gameObject);
            }
            
            _activeSlots.Clear();
        }

        private void ReturnItemsToInventory()
        {
            foreach (var slot in _activeSlots)
            {
                if (slot.IsFilled)
                {
                    Services.Inventory.AddItem(slot.InsertedItem, 1);
                }
            }
        }

        private void ChangeRecipe(int direction)
        {
            _currentRecipeIndex = (_currentRecipeIndex + direction + _recipes.Count) % _recipes.Count;
            _currentRecipe = _recipes[_currentRecipeIndex];
            ShowRecipe();
        }

        private void NextButton_OnClick()
        {
            ChangeRecipe(1);
        }

        private void PreviousButton_OnClick()
        {
            ChangeRecipe(-1);
        }
        
        private void ExitButton_OnClick()
        {
            ReturnItemsToInventory();
            gameObject.SetActive(false);
        }

        private async void ForgeButton_OnClick()
        {
            foreach (var slot in _activeSlots)
            {
                slot.ClearSlot();
            }
            
            progressBar.ShowProgress(_currentMachine.Data.ProcessTime);
            await _currentMachine.StartProcessing(_currentRecipe);
            progressBar.FinishProgress();
        }
    }
}
