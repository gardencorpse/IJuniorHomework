using System;
using TMPro;
using UnityEngine;

namespace counter
{
    public class CounterView : MonoBehaviour
    {
        [SerializeField] private Counter _counter;
        [SerializeField] private TextMeshProUGUI _text;
        private string _textTitle = "Count: ";

        private void OnEnable()
        {
            _counter.OnCountChanged += ChangeCountView;
        }

        private void OnDisable()
        {
            _counter.OnCountChanged -= ChangeCountView;
        }

        private void ChangeCountView()
        {
            _text.text = _textTitle + _counter.Count.ToString();
        }
    }
}