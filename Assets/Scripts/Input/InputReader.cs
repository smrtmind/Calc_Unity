using UnityEngine;

namespace Scripts.Input
{
    public class InputReader : MonoBehaviour
    {
        private CalculatorController _calculator;

        private string _currentNumber;
        public string CurrentNumber
        {
            get => _currentNumber;
            set => _currentNumber = value;
        }

        private string _inMemoryNumber;
        public string InMemoryNumber
        {
            get => _inMemoryNumber;
            set => _inMemoryNumber = value;
        }

        private void Awake()
        {
            _calculator = FindObjectOfType<CalculatorController>();
        }

        public void SetDigit(string digit)
        {
            _currentNumber += digit;

            _calculator._plus = true;
            _calculator._minus = true;
            _calculator._divide = true;
            _calculator._multiple = true;
            _calculator._separator = true;
        }

        public void Separator()
        {
            _calculator.Separator();
            _calculator._separator = false;
        }

        public void OnEquals()
        {
            _inMemoryNumber = string.Empty;
            _currentNumber = $"{_calculator.Result}";
        }

        public void OnCancel()
        {
            CurrentNumber = "0"; //error
        }
    }
}
