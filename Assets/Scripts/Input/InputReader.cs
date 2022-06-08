using UnityEngine;

namespace Scripts.Input
{
    public class InputReader : MonoBehaviour
    {
        private CalculatorController _calculator;

        private string _number;
        public string Number
        {
            get => _number;
            set => _number = value;
        }

        private void Awake()
        {
            _calculator = FindObjectOfType<CalculatorController>();
        }

        public void SetDigit(string digit) => _number += digit;

        public void SetOperator(string symbol) => _number += symbol;

        public enum Operator
        {
            Cancel,
            Parentheses,
            Percent,
            Divider,
            Multiplier,
            Minus,
            Plus,
            NegativePositive,
            Separator,
            Equals
        }
    }
}
