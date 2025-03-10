using System;
using UnityEngine;

namespace counter
{
    public class InputHandler : MonoBehaviour
    {
        public event Action OnMouseClicked;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnMouseClicked?.Invoke();
            }
        }
    }
}