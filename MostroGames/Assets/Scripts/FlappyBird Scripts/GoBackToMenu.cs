using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour {
    
    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
        PauseButton.isPaused = false;
        PlayerMovement.isGameOver = false;
        UpdateScore.score = 0;
    }
}
