using UnityEngine;

namespace Services.Score
{
    public class ScoreCounter : MonoBehaviour
    {
        private const string RecordScoreSaveKey = "RecordScoreKey";
    
        private int _recordScore;
        private int _score;

        public int RecordScore
        {
            get => _recordScore;
            private set
            {
                _recordScore = value;
                PlayerPrefs.SetInt(RecordScoreSaveKey, RecordScore);
                PlayerPrefs.Save();
                GlobalEvents.OnRecordScoreChanged?.Invoke(_recordScore);
            }
        }

        public int Score
        {
            get => _score;
            private set
            {
                _score = value < 0 ? 0 : value;
                if (Score > RecordScore) RecordScore = Score;
                GlobalEvents.OnScoreChanged?.Invoke(_score);
            }
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey(RecordScoreSaveKey)) return;
        
            RecordScore = PlayerPrefs.GetInt(RecordScoreSaveKey);
        }

        private void OnEnable() => GlobalEvents.OnRocketMoved.AddListener(SetNewScore);
        
        private void OnDisable() => GlobalEvents.OnRocketMoved.RemoveListener(SetNewScore);

        private void SetNewScore(int score) => Score = score / 10;
    }
}