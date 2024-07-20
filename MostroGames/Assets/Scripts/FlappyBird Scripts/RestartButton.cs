using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour { 

    public void RestartGame() {
        PlayerMovement.isGameOver = false;
        PlayerController.isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UpdateScore.score = 0;
        PlayerController.score = 0;
    }
}
