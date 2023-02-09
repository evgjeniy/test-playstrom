using Moving;
using UnityEngine;

namespace Obstacles
{
    [RequireComponent(typeof(Collider))]
    public class ObstacleTemplate : MonoBehaviour
    {
        [SerializeField] private ObstacleTemplate obstaclesPrefab;
        [SerializeField] private Transform spawnPoint;

        private void Start() => GetComponent<Collider>().isTrigger = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out RocketMovement _)) return;

            Instantiate(obstaclesPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}