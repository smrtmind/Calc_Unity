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

        //private void Update()
        //{
        //    _separatorIsUsed = false;

        //    if (_input.CurrentNumber != default && _input.CurrentNumber.Length > 0)
        //    {
        //        if (_input.MathOperator == "+")
        //        {
        //            if (_firstOperation)
        //            {
        //                _result = Convert.ToDecimal(_input.CurrentNumber);
        //                _firstOperation = false;
        //            }
        //            else
        //            {
        //                _result += Convert.ToDecimal(_input.CurrentNumber);
        //            }

        //            _input.MathOperator = string.Empty;
        //            _input.InMemoryNumber = $"{_result} +";
        //        }

        //        //_input.CurrentNumber = string.Empty;
        //    }
        //}

        //public void Plus()
        //{
        //    _separatorIsUsed = false;

        //    if (_plus && _input.CurrentNumber.Length > 0)
        //    {
        //        _input.InMemoryNumber = string.Empty;
        //        _input.InMemoryNumber = _input.CurrentNumber;

        //        if (_firstOperation)
        //        {
        //            _result = Convert.ToDecimal(_input.CurrentNumber);
        //            _firstOperation = false;
        //        }
        //        else
        //        {
        //            _result += Convert.ToDecimal(_input.CurrentNumber);
        //        }

        //        //if (_negative)
        //        //    _result *= -1;
        //        //else
        //        //    _result *= 1;

        //        _input.InMemoryNumber = $"{_result} +";

        //        _input.CurrentNumber = string.Empty;

        //        _plus = false;
        //    }
        //}

        public void Separator()
        {
            if (_separator && !_separatorIsUsed)
                _input.CurrentNumber += ",";

            _separatorIsUsed = true;
        }

        public void MoveResult()
        {
            _input.InMemoryNumber = string.Empty;
            _input.InMemoryNumber = _input.CurrentNumber;
        }

        public void Equals()
        {
            var currentNumber = Convert.ToDecimal(_input.CurrentNumber);

            _separatorIsUsed = false;

            if (_firstOperation)
            {
                _result = currentNumber;
                _firstOperation = false;
            }

            if (_input.CurrentNumber.Length > 0)
            {
                if (_input.MathOperator == "+")
                {
                    _result += currentNumber;
                    _plus = false;
                }
                if (_input.MathOperator == "-")
                {
                    _result -= currentNumber;
                    _minus = false;
                }
                if (_input.MathOperator == "/")
                {
                    _result /= currentNumber;
                    _divide = false;
                }
                if (_input.MathOperator == "*")
                {
                    _result *= currentNumber;
                    _multiple = false;
                }
            }

            _input.InMemoryNumber = $"{_result} {_sign}";
            _input.CurrentNumber = string.Empty;
        }

        public void SetSigh(string sign) => _sign = sign;
    }
}
