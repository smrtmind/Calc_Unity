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

        private bool _divideByZeroException;
        public bool DivideByZeroException
        {
            get => _divideByZeroException;
            set => _divideByZeroException = value;
        }
        private string _sign;
        private bool _separatorIsFound;

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
        public bool _negative { get; set; }

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
                //check if user already entered separator
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
        }

        public void GetResult()
        {
            //to avoid multiply/divide on zero, because on start first operation will add/minus/divide/multiply with default digit 0
            if (_firstOperation)
            {
                _result = Convert.ToDecimal(_input.CurrentNumber);
                _firstOperation = false;
            }

            //if user entered something
            if (_input.CurrentNumber.Length > 0)
            {
                var currentNumber = Convert.ToDecimal(_input.CurrentNumber);

                switch (_input.MathOperator)
                {
                    case "+":
                        _result += currentNumber;
                        _plus = false;
                        break;

                    case "-":
                        _result -= currentNumber;
                        _minus = false;
                        break;

                    case "/":
                        //prevent dividing by zero and throw message
                        if (currentNumber == 0)
                        {
                            _input.InMemoryNumber = string.Empty;
                            _input.CurrentNumber = $"division by zero is not allowed";
                            _divideByZeroException = true;

                            //deactivate all buttons except C
                            foreach (var button in _hud.Buttons)
                            {
                                button.interactable = false;
                                button.GetComponent<EventTrigger>().enabled = false;
                            }

                            return;
                        }
                        else
                        {
                            _result /= currentNumber;
                            _divide = false;
                        }
                        break;

                    case "*":
                        _result *= currentNumber;
                        _multiple = false;
                        break;
                }
            }

            _input.InMemoryNumber = $"{_result} {_sign}";
            _input.CurrentNumber = string.Empty;
        }

        public void SetSigh(string sign) => _sign = sign;
    }
}
