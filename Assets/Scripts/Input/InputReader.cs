using UnityEngine;

namespace Scripts.Input
{
    public class InputReader : MonoBehaviour
    {
        private CalculatorController _calculator;

        private float _digit;
        public float Digit
        {
            get => _digit;
            set => _digit = value;
        }

        private void Awake()
        {
            _calculator = FindObjectOfType<CalculatorController>();
        }

        public void SetDigit(float digit) => _digit = digit;
    }
}
