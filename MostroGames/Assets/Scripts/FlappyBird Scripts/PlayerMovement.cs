using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject gameOverSprite;
    public GameObject restartButton;
    public GameObject returnToMenuButton;
    public GameObject pauseCanva;
    public GameObject pauseButton;

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
        if(Input.GetMouseButtonDown(0) && !isGameOver && !PauseButton.isPaused) {
            rb.velocity = new Vector2(0, playerJumpSpeed);
            audioSource.PlayOneShot(jump);
        }

        if(isGameOver) {
            gameOverSprite.SetActive(true);
            restartButton.SetActive(true);
            returnToMenuButton.SetActive(true);
            pauseButton.SetActive(false);

        } else if(PauseButton.isPaused) {
            pauseCanva.SetActive(true);
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            pauseButton.SetActive(false);

        } else {
            gameOverSprite.SetActive(false);
            restartButton.SetActive(false);
            returnToMenuButton.SetActive(false);
            pauseCanva.SetActive(false);
            pauseButton.SetActive(true);
            rb.gravityScale = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Tubi") 
            || collision.gameObject.CompareTag("Ground")) {
            isGameOver = true;
            audioSource.PlayOneShot(death);
        }
    }
}
