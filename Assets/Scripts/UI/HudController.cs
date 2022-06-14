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

        public Button[] Buttons => _buttons;

        private InputReader _input;

        private void Awake()
        {
            _input = FindObjectOfType<InputReader>();
        }

        private void Update()
        {
            if (_input.CurrentNumber != default)
            {
                if (_input.CurrentNumber.Length < 8)
                    _currentInput.fontSize = 200;
                else if (_input.CurrentNumber.Length > 8 && _input.CurrentNumber.Length < 11)
                    _currentInput.fontSize = 150;
                else if (_input.CurrentNumber.Length > 11)
                    _currentInput.fontSize = 100;
            }

            _inMemoryInput.text = $"{_input.InMemoryNumber}";
            _currentInput.text = $"{_input.CurrentNumber}";
        }
    }
}
