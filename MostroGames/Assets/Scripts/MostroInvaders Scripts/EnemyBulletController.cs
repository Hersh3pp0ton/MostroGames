using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

    [HideInInspector] public static float bulletSpeed = 5.0f;
    private float yLimit = -7f;

    private AudioSource audioSource;
    public AudioClip gameOverSound;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if(!PlayerController.isGameOver && !PauseButton.isPaused) {
            transform.Translate(Vector3.down * bulletSpeed * Time.deltaTime);
        }

        if (transform.position.y <= yLimit) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
            audioSource.PlayOneShot(gameOverSound);
            PlayerController.isGameOver = true;
        }
    }
}
