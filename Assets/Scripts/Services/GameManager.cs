using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class GameManager : MonoBehaviour
    {
        private void OnEnable() => GlobalEvents.OnGameOver.AddListener(GameOver);
        
        private void OnDisable() => GlobalEvents.OnGameOver.RemoveListener(GameOver);

        private void GameOver() => StartCoroutine(ReloadScene());

        private IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
