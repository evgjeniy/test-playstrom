using UnityEngine;
using UnityEngine.UI;

namespace Services.Score
{
    [RequireComponent(typeof(Text))]
    public class BaseScoreText : ScoreText
    {
        private void OnEnable() => GlobalEvents.OnScoreChanged.AddListener(SetScore);

        private void OnDisable() => GlobalEvents.OnScoreChanged.RemoveListener(SetScore);
    }
}