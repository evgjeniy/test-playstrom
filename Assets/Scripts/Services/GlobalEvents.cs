using UnityEngine.Events;

namespace Services
{
    public static class GlobalEvents
    {
        public static UnityEvent OnGameOver = new();
        public static UnityEvent<int> OnScoreChanged = new();
        public static UnityEvent<int> OnRocketMoved = new();
        public static UnityEvent<int> OnRecordScoreChanged = new();
    }
}