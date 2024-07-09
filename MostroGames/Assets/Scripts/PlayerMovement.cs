using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject gameOverSprite;
    public GameObject restartButton;
    public GameObject returnToMenuButton;

    private AudioSource audioSource;
    public AudioClip jump;
    public AudioClip death;

    private float playerJumpSpeed = 7f;
    [HideInInspector] public static bool isGameOver = false;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && !isGameOver) {
            rb.velocity = new Vector2(0, playerJumpSpeed);
            audioSource.PlayOneShot(jump);
        }
        if(isGameOver) {
            gameOverSprite.SetActive(true);
            restartButton.SetActive(true);
            returnToMenuButton.SetActive(true);

        } else {
            gameOverSprite.SetActive(false);
            restartButton.SetActive(false);
            returnToMenuButton.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isGameOver = true;
        audioSource.PlayOneShot(death);
    }
}
