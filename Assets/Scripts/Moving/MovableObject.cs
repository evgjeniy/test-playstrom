using Services;
using UnityEngine;

namespace Moving
{
    public abstract class MovableObject<T> : MonoBehaviour
    {
        protected T Component;
        protected Transform Transform;
    
        protected virtual void Awake()
        {
            Component = GetComponent<T>();
            Transform = transform;
        }

        protected virtual void OnEnable()
        {
            PlayerInput.OnTouchScreen += Move;
            PlayerInput.OnLastTouchScreen += Rotate;
        }

        protected virtual void OnDisable()
        {
            PlayerInput.OnTouchScreen -= Move;
            PlayerInput.OnLastTouchScreen -= Rotate;
        }

        protected abstract void Move(Touch touch);
        protected abstract void Rotate(Touch touch);
    }
}