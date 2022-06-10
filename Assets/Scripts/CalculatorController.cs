using Scripts.Input;
using System;
using UnityEngine;

namespace Scripts
{
    public class CalculatorController : MonoBehaviour
    {
        private InputReader _input;

        public bool _plus { get; set; }
        public bool _minus { get; set; }
        public bool _divide { get; set; }
        public bool _multiple { get; set; }
        public bool _result { get; set; }

        private void Awake()
        {
            _input = FindObjectOfType<InputReader>();
        }

        private void Update()
        {
            if (_result)
            {

            }   

            if (_plus)
            {
                var result = Convert.ToDouble(_input.Number);
            }
        }
    }
}
