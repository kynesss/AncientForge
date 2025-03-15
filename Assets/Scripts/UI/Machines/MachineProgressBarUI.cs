using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Machines
{
    public class MachineProgressBarUI : MonoBehaviour
    {
        [SerializeField] private Image progressBarFill;
        [SerializeField] private TextMeshProUGUI progressText;

        private float _processTime;
        private float _elapsedTime;

        public void ShowProgress(float processTime)
        {
            gameObject.SetActive(true);
            
            _processTime = processTime;
            _elapsedTime = 0f;
        }

        public void FinishProgress()
        {
            progressBarFill.fillAmount = 0;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_processTime <= 0f) 
                return;

            _elapsedTime += Time.deltaTime;
            
            var progress = Mathf.Clamp01(_elapsedTime / _processTime);
            UpdateProgressUI(progress);

            if (_elapsedTime >= _processTime)
            {
                FinishProgress();
            }
        }

        private void UpdateProgressUI(float progress)
        {
            progressBarFill.fillAmount = progress;
            progressText.text = $"Crafting: {(progress * 100):0}%";
        }
    }
}