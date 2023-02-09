namespace Services.Score
{
    public class RecordScoreText : ScoreText
    {
        private void OnEnable() => GlobalEvents.OnRecordScoreChanged.AddListener(SetScore);

        private void OnDisable() => GlobalEvents.OnRecordScoreChanged.RemoveListener(SetScore);

        protected override void SetScore(int score) => Text.text = $"Best: {score}";
    }
}