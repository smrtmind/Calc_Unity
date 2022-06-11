using Scripts.Input;
using System;
using UnityEngine;

namespace Scripts
{
    public class CalculatorController : MonoBehaviour
    {
        private InputReader _input;

        private bool _firstOperation = true;
        private double _number;
        private double _result;
        public double Result => _result;

        public bool _plus { get; set; }
        public bool _minus { get; set; }
        public bool _divide { get; set; }
        public bool _multiple { get; set; }
        public bool _separator { get; set; }

        private void Awake()
        {
            _input = FindObjectOfType<InputReader>();
        }

        public void Plus()
        {
            if (_plus && _input.CurrentNumber.Length > 0)
            {
                _input.InMemoryNumber = string.Empty;
                _input.InMemoryNumber = _input.CurrentNumber;

                if (_firstOperation)
                {
                    _result = Convert.ToDouble(_input.CurrentNumber);
                    _firstOperation = false;
                }
                else
                {
                    _result += Convert.ToDouble(_input.CurrentNumber);
                }

                _input.InMemoryNumber = $"{_result}+";

                _input.CurrentNumber = string.Empty;

                _plus = false;
            }
        }

        public void Minus()
        {
            if (_minus && _input.CurrentNumber.Length > 0)
            {
                _input.InMemoryNumber = string.Empty;
                _input.InMemoryNumber = _input.CurrentNumber;

                if (_firstOperation)
                {
                    _result = Convert.ToDouble(_input.CurrentNumber);
                    _firstOperation = false;
                }
                else
                {
                    _result -= Convert.ToDouble(_input.CurrentNumber);
                }

                _input.InMemoryNumber = $"{_result}-";

                _input.CurrentNumber = string.Empty;

                _minus = false;
            }
        }

        public void Divide()
        {
            if (_divide && _input.CurrentNumber.Length > 0)
            {
                _input.InMemoryNumber = string.Empty;
                _input.InMemoryNumber = _input.CurrentNumber;

                if (_firstOperation)
                {
                    _result = Convert.ToDouble(_input.CurrentNumber);
                    _firstOperation = false;
                }
                else
                {
                    _result /= Convert.ToDouble(_input.CurrentNumber);
                }

                _input.InMemoryNumber = $"{_result}/";

                _input.CurrentNumber = string.Empty;

                _divide = false;
            }
        }

        public void Multiple()
        {
            if (_multiple && _input.CurrentNumber.Length > 0)
            {
                _input.InMemoryNumber = string.Empty;
                _input.InMemoryNumber = _input.CurrentNumber;

                if (_firstOperation)
                {
                    _result = Convert.ToDouble(_input.CurrentNumber);
                    _firstOperation = false;
                }
                else
                {
                    _result *= Convert.ToDouble(_input.CurrentNumber);
                }

                _input.InMemoryNumber = $"{_result}*";

                _input.CurrentNumber = string.Empty;

                _multiple = false;
            }
        }

        public void Separator()
        {
            if (_separator)
                _input.CurrentNumber += ",";
        }
    }
}
