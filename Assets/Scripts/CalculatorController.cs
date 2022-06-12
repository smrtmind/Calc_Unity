using Scripts.Input;
using System;
using UnityEngine;

namespace Scripts
{
    public class CalculatorController : MonoBehaviour
    {
        private InputReader _input;

        private string _sign;
        private bool _separatorIsUsed;

        private bool _firstOperation = true;
        public bool FirstOperation
        {
            get => _firstOperation;
            set => _firstOperation = value;
        }

        private decimal _result;
        public decimal Result
        {
            get => _result;
            set => _result = value;
        }

        public bool _plus { get; set; }
        public bool _minus { get; set; }
        public bool _divide { get; set; }
        public bool _multiple { get; set; }
        public bool _separator { get; set; }
        public bool _negative { get; set; }

        private void Awake()
        {
            _input = FindObjectOfType<InputReader>();
        }

        public void Separator()
        {
            if (_input.CurrentNumber != null)
            {
                foreach (var symbol in _input.CurrentNumber.ToCharArray())
                {
                    if (symbol == ',')
                    {
                        _separatorIsUsed = true;
                        break;
                    }
                    else _separatorIsUsed = false;
                }
            }

            if (_separator && !_separatorIsUsed)
            {
                if (_input.CurrentNumber.Length > 0)
                    _input.CurrentNumber += ",";
                else return;
            }
        }

        public void MoveResult()
        {
            _input.InMemoryNumber = string.Empty;
            _input.InMemoryNumber = _input.CurrentNumber;
        }

        public void Equals()
        {
            //_separatorIsUsed = false;

            if (_firstOperation)
            {
                _result = GetConvertedNumber(_input.CurrentNumber);
                _firstOperation = false;
            }

            if (_input.CurrentNumber.Length > 0)
            {
                if (_input.MathOperator == "+")
                {
                    _result += GetConvertedNumber(_input.CurrentNumber);
                    _plus = false;
                }
                if (_input.MathOperator == "-")
                {
                    _result -= GetConvertedNumber(_input.CurrentNumber);
                    _minus = false;
                }
                if (_input.MathOperator == "/")
                {
                    _result /= GetConvertedNumber(_input.CurrentNumber);
                    _divide = false;
                }
                if (_input.MathOperator == "*")
                {
                    _result *= GetConvertedNumber(_input.CurrentNumber);
                    _multiple = false;
                }
            }

            _input.InMemoryNumber = $"{_result} {_sign}";
            _input.CurrentNumber = string.Empty;
        }

        public void SetSigh(string sign) => _sign = sign;

        private decimal GetConvertedNumber(string number) => Convert.ToDecimal(number);
    }
}
