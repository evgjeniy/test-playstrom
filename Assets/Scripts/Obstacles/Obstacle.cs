using Moving;
using Services;
using UnityEngine;

namespace Obstacles
{
    [RequireComponent(typeof(Collider))]
    public class Obstacle : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.collider.TryGetComponent(out RocketMovement _)) return;
            
            GlobalEvents.OnGameOver?.Invoke();
        }
    }
}