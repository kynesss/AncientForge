using MachineSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Machines
{
    public class MachineUI : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Machine machine;
        [SerializeField] private MachineForgeUI machineForgeUI;

        private void OnEnable()
        {
            button.onClick.AddListener(Button_OnClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Button_OnClick);
        }

        private void Button_OnClick()
        {
            machineForgeUI.Open(machine);
        }
    }
}