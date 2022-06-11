using Scripts.Input;
using System;
using UnityEngine;

namespace Scripts
{
    public class CalculatorController : MonoBehaviour
    {
        private InputReader _input;

        private double _number;
        private double _result;
        public double Result => _result;

        public bool _plus { get; set; }
        public bool _minus { get; set; }
        public bool _divide { get; set; }
        public bool _multiple { get; set; }
        public bool _separator { get; set; }
        public bool _equals { get; set; }

        private void Awake()
        {
            _input = FindObjectOfType<InputReader>();
        }

        public void Plus()
        {
            if (_plus)
            {
                _input.InMemoryNumber = string.Empty;
                _input.InMemoryNumber = _input.CurrentNumber;

                _result += Convert.ToDouble(_input.CurrentNumber);

                _input.InMemoryNumber = _input.CurrentNumber + "+";

                _input.CurrentNumber = string.Empty;
            }
        }

        public void Minus()
        {

        }

        public void Divide()
        {

        }

        public void Multiple()
        {

        }

        public void Separator()
        {
            if (_separator)
            {
                _input.CurrentNumber += ",";
            }
        }

        public void Equals()
        {

        }
    }
}
