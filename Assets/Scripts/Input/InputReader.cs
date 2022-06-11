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

        public void Plus()
        {
            _calculator.Plus();
            _calculator._plus = false;
        }

        public void Minus()
        {
            _calculator.Minus();
            _calculator._minus = false;
        }
        public void Multiple()
        {
            _calculator.Multiple();
            _calculator._multiple = false;
        }

        public void Divide()
        {
            _calculator.Divide();
            _calculator._divide = false;
        }

        public void Equals()
        {
            _calculator.Equals();
            _calculator._equals = false;
        }

        public void OnCancel()
        {
            CurrentNumber = "0"; //error
        }

        //public enum Operator
        //{
        //    Parentheses,
        //    Percent,
        //    Divider,
        //    Multiplier,
        //    Minus,
        //    Plus,
        //    NegativePositive,
        //    Separator
        //}
    }
}
