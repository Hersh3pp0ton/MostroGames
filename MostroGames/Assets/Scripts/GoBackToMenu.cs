using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour {
    
    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
    }
}
