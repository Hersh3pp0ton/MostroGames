using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject gameOverSprite;
    public GameObject restartButton;

    private float playerJumpSpeed = 7f;
    [HideInInspector] public static bool isGameOver = false;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && !isGameOver) {
            rb.velocity = new Vector2(0, playerJumpSpeed);
        }
        if(isGameOver) {
            gameOverSprite.SetActive(true);
            restartButton.SetActive(true);
        }
        if(!isGameOver) {
            gameOverSprite.SetActive(false);
            restartButton.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isGameOver = true;
    }
}
