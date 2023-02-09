using UnityEngine;
using UnityEngine.UI;

namespace Services.Score
{
    [RequireComponent(typeof(Text))]
    public abstract class ScoreText : MonoBehaviour
    {
        protected Text Text;

        private void Awake() => Text = GetComponent<Text>();

        protected virtual void SetScore(int score) => Text.text = score.ToString();
    }
}