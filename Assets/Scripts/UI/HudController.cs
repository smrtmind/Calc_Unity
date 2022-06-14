using Scripts.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;
        [SerializeField] private Text _inMemoryInput;
        [SerializeField] private Text _currentInput;

        public Button[] Buttons
        {
            get => _buttons;
            set => _buttons = value;
        }

        private InputReader _input;
        private CalculatorController _calculator;

        private void Awake()
        {
            _input = FindObjectOfType<InputReader>();
            _calculator = FindObjectOfType<CalculatorController>();
        }

        private void Update()
        {
            if (_input.CurrentNumber != default)
            {
                if (_input.CurrentNumber.Length < 8)
                    _currentInput.fontSize = 200;
                else if (_input.CurrentNumber.Length > 8 && _input.CurrentNumber.Length < 12)
                    _currentInput.fontSize = 150;
                else if (_input.CurrentNumber.Length > 12)
                    _currentInput.fontSize = 100;
            }

            _inMemoryInput.text = $"{_input.InMemoryNumber}";
            _currentInput.text = $"{_input.CurrentNumber}";
        }

        public void OnNegative()
        {
            if (!_calculator._negative)
                _calculator._negative = true;
            else
                _calculator._negative = false;
        }

        public void OnDelete()
        {
            if (_input.CurrentNumber.Length > 0)
            {
                char[] tempArray = new char[_input.CurrentNumber.Length - 1];

                for (int i = 0; i < tempArray.Length; i++)
                    tempArray[i] = _input.CurrentNumber[i];

                _input.CurrentNumber = new string(tempArray);
            }
        }

        public void OnExit()
        {
            Application.Quit();
        }
    }
}
