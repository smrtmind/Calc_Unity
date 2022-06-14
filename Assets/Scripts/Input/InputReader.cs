using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Input
{
    public class InputReader : MonoBehaviour
    {
        private CalculatorController _calculator;

        private string _mathOperator;
        public string MathOperator
        {
            get => _mathOperator;
            set => _mathOperator = value;
        }

        private string _currentNumber;
        public string CurrentNumber
        {
            get => _currentNumber;
            set => _currentNumber = value;
        }

        private string _inMemoryNumber;
        public string InMemoryNumber
        {
            get => _inMemoryNumber;
            set => _inMemoryNumber = value;
        }

        private void Awake()
        {
            _calculator = FindObjectOfType<CalculatorController>();
        }

        public void SetDigit(string digit)
        {
            //if (_calculator._negative && _currentNumber.Length > 0)
            //    _currentNumber += "-" + digit;
            //else
            _currentNumber += digit;

            ResetOperatorsAccess();
        }

        public void SetOperator(string mathOperator) => _mathOperator = mathOperator;

        public void Separator() => _calculator.UseSeparator();

        public void OnEquals()
        {
            _calculator.GetResult();

            if (!_calculator.DivideByZeroException)
            {
                _inMemoryNumber = string.Empty;
                _mathOperator = string.Empty;
                _currentNumber = $"{_calculator.Result}";
            }

            _calculator.FirstOperation = true;

            ResetOperatorsAccess();
        }

        public void OnCancel()
        {
            var sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);

            //_inMemoryNumber = string.Empty;
            //_currentNumber = string.Empty;
            //_mathOperator = string.Empty;
            //_calculator.Result = default;
            //_calculator.FirstOperation = true;
        }

        private void ResetOperatorsAccess()
        {
            _calculator._plus = true;
            _calculator._minus = true;
            _calculator._divide = true;
            _calculator._multiple = true;
        }
    }
}
