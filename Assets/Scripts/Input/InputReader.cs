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

        public void Plus() => _calculator._plus = true;
        public void Minus() => _calculator._minus = true;
        public void Multiple() => _calculator._multiple = true;
        public void Divide() => _calculator._divide = true;
        public void Result() => _calculator._result = true;

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
