using Scripts.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] private Text _display;

        private InputReader _input;

        private void Awake()
        {
            _input = FindObjectOfType<InputReader>();
        }

        private void Update()
        {
            _display.text = $"{_input.Digit}";
        }

        public void OnCancel()
        {
            _input.Digit = 0;
        }

        public void OnExit()
        {
            Application.Quit();
        }
    }
}
