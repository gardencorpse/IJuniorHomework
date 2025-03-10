using System;
using System.Collections;
using UnityEngine;

namespace counter
{
    public class Counter : MonoBehaviour
    {
        [SerializeField] private float _delay = 0.5f;
        [SerializeField] private float _step = 1f;
        [SerializeField] private InputHandler _inputHandler;

        private float _count = 0f;
        private bool _isLaunch = false;
        private Coroutine _coroutine;

        public event Action OnCountChanged;

        public float Count => _count;

        private void OnEnable()
        {
            _inputHandler.OnMouseClicked += ChangeState;
        }

        private void OnDisable()
        {
            _inputHandler.OnMouseClicked -= ChangeState;
        }

        private void ChangeState()
        {
            _isLaunch = !_isLaunch;

            if (_isLaunch)
            {
                _coroutine = StartCoroutine(LaunchCounter());
            }
            else
            {
                StopCoroutine(_coroutine);
            }
        }

        private IEnumerator LaunchCounter()
        {
            var wait = new WaitForSeconds(_delay);

            while (_isLaunch)
            {
                _count += _step;
                OnCountChanged?.Invoke();
                yield return wait;
            }
        }
    }
}

