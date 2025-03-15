using System;
using System.Collections.Generic;
using Core;
using QuestSystem;
using UnityEngine;

namespace UI.Machines
{
    public class MachineManagerUI : MonoBehaviour
    {
        [SerializeField] private List<MachineUI> machines;

        private void Start()
        {
            foreach (var machineUI in machines)
            {
                machineUI.Block();
            }
        }

        private void OnEnable()
        {
            Services.QuestManager.QuestCompleted += OnQuestCompleted;
        }

        private void OnDisable()
        {
            Services.QuestManager.QuestCompleted -= OnQuestCompleted;
        }

        private void OnQuestCompleted(QuestData quest)
        {
            var data = quest.MachineToUnlock;

            foreach (var machineUI in machines)
            {
                machineUI.TryUnlock(data);
            }
        }
    }
}
