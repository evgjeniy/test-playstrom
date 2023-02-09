using Services;
using UnityEngine;

namespace Moving
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        private Transform _transform;

        private void Start() => _transform = transform;

        private void Update()
        {
            if (Vector3.Distance(_transform.position, target.position) >= offset.magnitude * 1.2f)
                GlobalEvents.OnGameOver?.Invoke();
            
            if (target.position.y < 0) return;
        
            _transform.position = Vector3.up * target.position.y + offset;
        }
    }
}
