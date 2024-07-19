using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGameButton : MonoBehaviour {
    
    public void ChangeToFlappyMostro() {
        SceneManager.LoadScene(1);
    }
    
    public void ChangeToMostroInvaders() {
        SceneManager.LoadScene(2);
    }
}
