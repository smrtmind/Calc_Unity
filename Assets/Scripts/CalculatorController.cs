using Scripts.Input;
using Scripts.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts
{
    public class CalculatorController : MonoBehaviour
    {
        private HudController _hud;
        private InputReader _input;

        private double _result;
        private double _currentNumber;
        private string _visualOperator;
        private bool _separatorIsFound;
        private bool _firstOperation = true;
        private bool _divideByZeroException;

        public double Result => _result;
        public bool DivideByZeroException => _divideByZeroException;

        public bool FirstOperation
        {
            get => _firstOperation;
            set => _firstOperation = value;
        }

        private void Awake()
        {
            _input = FindObjectOfType<InputReader>();
            _hud = FindObjectOfType<HudController>();
        }

        public void UseSeparator()
        {
            //if it is not first operation after start
            if (_input.CurrentNumber != null)
            {
                foreach (var symbol in _input.CurrentNumber.ToCharArray())
                {
                    if (symbol == ',')
                    {
                        _separatorIsFound = true;
                        break;
                    }
                    else _separatorIsFound = false;
                }

                if (!_separatorIsFound)
                {
                    if (_input.CurrentNumber.Length > 0)
                        _input.CurrentNumber += ",";
                    else
                        _input.CurrentNumber += "0,";
                }
            }
            //if it is first operation after start
            else
                _input.CurrentNumber += "0,";

            _hud.DisplayResult();
        }

        public void GetResult()
        {
            //to avoid multiply/divide on zero, because on start first operation will add/minus/divide/multiply with default digit 0
            if (_firstOperation)
            {
                _result = Convert.ToDouble(_input.CurrentNumber);
                _firstOperation = false;
            }

            //if user entered something
            if (_input.CurrentNumber != null)
            {
                if (_input.CurrentNumber.Length > 0)
                {
                    _currentNumber = Convert.ToDouble(_input.CurrentNumber);

                    if (_input.MathOperator == "+") Plus();
                    if (_input.MathOperator == "-") Minus();
                    if (_input.MathOperator == "*") Multiply();

                    if (_input.MathOperator == "/") Divide();
                    if (_divideByZeroException) return;
                }
            }
            else
            {
                _input.CurrentNumber = null;
                return;
            }

            _input.InMemoryNumber = $"{GetCorrectOutput()} {_visualOperator}";
            _input.CurrentNumber = string.Empty;

            _hud.DisplayResult();
        }

        //operator which you see when doing continuous operations one by one
        public void SetVisualOperator(string visualOperator) => _visualOperator = visualOperator;

        private void Plus() => _result += _currentNumber;

        private void Minus() => _result -= _currentNumber;

        private void Multiply() => _result *= _currentNumber;

        private void Divide()
        {
            //prevent dividing by zero and throw message
            if (_currentNumber == 0)
            {
                _input.InMemoryNumber = string.Empty;
                _input.CurrentNumber = $"division by zero is not allowed";
                _divideByZeroException = true;

                //deactivate all buttons except button 'C'
                foreach (var button in _hud.Buttons)
                {
                    button.interactable = false;
                    button.GetComponent<EventTrigger>().enabled = false;
                }

                _hud.DisplayResult();

                return;
            }
            else _result /= _currentNumber;
        }

        public string GetCorrectOutput()
        {
            //if number with decimal point, need to check digits after it
            if (_separatorIsFound)
            {
                var splittedBySeparatorArray = $"{_result}".Split(',');

                //take digits after separator, on index 1
                var digitsAfterSeparator = splittedBySeparatorArray[1];

                int zeroCounter = default;

                for (int i = 0; i < digitsAfterSeparator.Length; i++)
                    if (digitsAfterSeparator[i] == '0')
                        zeroCounter++;

                //if amount of zeroes is equal to all digits after separator, remove all zeroes and separator
                if (zeroCounter == digitsAfterSeparator.Length)
                    return $"{splittedBySeparatorArray[0]}";
                //other way show full number
                else
                    return $"{_result}";
            }
            else
                return $"{_result}";
        }
    }
}
