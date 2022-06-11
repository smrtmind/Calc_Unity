using Scripts.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private Text _inMemoryInput;
        [SerializeField] private Text _currentInput;

        private InputReader _input;
        private CalculatorController _calculator;

        private void Awake()
        {
            _input = FindObjectOfType<InputReader>();
            _calculator = FindObjectOfType<CalculatorController>();
        }

        private void Update()
        {
            _inMemoryInput.text = $"{_calculator.Result}";
            _currentInput.text = $"{_input.CurrentNumber}";
        }

        public void OnExit()
        {
            Application.Quit();
        }
    }
}
