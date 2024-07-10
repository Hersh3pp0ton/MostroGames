using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour { 

    public void RestartGame() {
        PlayerMovement.isGameOver = false;
        SceneManager.LoadScene(1);
        UpdateScore.score = 0;
    }
}
