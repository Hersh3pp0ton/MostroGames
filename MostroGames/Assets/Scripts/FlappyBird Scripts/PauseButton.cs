using UnityEngine;

public class PauseButton : MonoBehaviour {

    public static bool isPaused = false;

    public void OnPauseButtonClick() {
        isPaused = !isPaused;
        Debug.Log(isPaused);
    }
}
