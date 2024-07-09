using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {

    private AudioSource audioSource;
    public Text scoreText;
    [HideInInspector] public static int score = 0;

    void Start() {
        InvokeRepeating("UpdateScoreText", 3f, 1f);
        audioSource = GetComponent<AudioSource>();
    }

    void UpdateScoreText() {
        if(!PlayerMovement.isGameOver) {
            score++;
            audioSource.Play();
            scoreText.text = score.ToString();
        }
    }
}
