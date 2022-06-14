using Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Input
{
    public class InputReader : MonoBehaviour
    {
        private CalculatorController _calculator;
        private HudController _hud;

        private string _mathOperator;
        private string _currentNumber;
        private string _inMemoryNumber;

        public string MathOperator
        {
            get => _mathOperator;
            set => _mathOperator = value;
        }

        public string CurrentNumber
        {
            get => _currentNumber;
            set => _currentNumber = value;
        }

        public string InMemoryNumber
        {
            get => _inMemoryNumber;
            set => _inMemoryNumber = value;
        }

        private void Awake()
        {
            _calculator = FindObjectOfType<CalculatorController>();
            _hud = FindObjectOfType<HudController>();
        }

        //operation using when buttons from 0 to 9 is pressing
        public void SetDigit(string digit)
        {
            _currentNumber += digit;

            //max available number has 16 digits length, as in Microsoft Calculator
            if (_currentNumber.Length > 16)
            {
                var tempNumber = _currentNumber.Substring(0, 16);
                _currentNumber = tempNumber;
            }

            _hud.DisplayResult();
        }

        //set active math operator which will be used on next step
        public void SetOperator(string mathOperator) => _mathOperator = mathOperator;

        //adding decimal pointer
        public void Separator() => _calculator.UseSeparator();

        //add or remove minus sign before the number, to make number negative or positive
        public void Negative()
        {
            if (_currentNumber != null)
            {
                if (_currentNumber.Length > 0)
                {
                    if (_currentNumber[0] == '-')
                        _currentNumber = _currentNumber.Remove(0, 1).ToString();
                    else
                        _currentNumber = _currentNumber.Insert(0, "-").ToString();
                }
            }

            _hud.DisplayResult();
        }

        //when user press button '='
        public void OnEquals()
        {
            _calculator.GetResult();

            //if user doesn't divide by zero
            if (!_calculator.DivideByZeroException)
            {
                _inMemoryNumber = string.Empty;
                _mathOperator = string.Empty;
                _currentNumber = $"{_calculator.Result}";
            }

            _calculator.FirstOperation = true;

            _hud.DisplayResult();
        }

        public void OnCancel()
        {
            var sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }

        public void OnDelete()
        {
            if (_currentNumber != null)
            {
                //if user deleted all digits, minus will remove automatically
                if (_currentNumber.Length == 2 && _currentNumber[0] == '-')
                    _currentNumber = string.Empty;

                if (_currentNumber.Length > 0)
                {
                    char[] tempArray = new char[_currentNumber.Length - 1];

                    for (int i = 0; i < tempArray.Length; i++)
                        tempArray[i] = _currentNumber[i];

                    _currentNumber = new string(tempArray);
                }
            }

            _hud.DisplayResult();
        }

        public void OnExit() => Application.Quit();
    }
}
