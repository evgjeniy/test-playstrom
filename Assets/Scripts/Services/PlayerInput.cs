using System;
using UnityEngine;

namespace Services
{
    public class PlayerInput : MonoBehaviour
    {
        private bool _isTouched;
    
        public static event Action<Touch> OnTouchScreen;
        public static event Action<Touch> OnLastTouchScreen;

        private void Update()
        {
            if (Input.touchCount == 0) return;

            var touch = Input.GetTouch(0);
            _isTouched = touch.phase switch
            {
                TouchPhase.Began => true,
                TouchPhase.Ended => false,
                _ => _isTouched
            };

            if (_isTouched) OnTouchScreen?.Invoke(touch);
            else OnLastTouchScreen?.Invoke(touch);
        }
    }
}