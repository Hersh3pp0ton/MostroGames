using UnityEngine;

public class EnemyBulletController : MonoBehaviour {

    private float bulletSpeed = 5.0f;
    private float yLimit = -7f;

    void Update() {
        if(!PlayerController.isGameOver && !PauseButton.isPaused) {
            transform.Translate(Vector3.down * bulletSpeed * Time.deltaTime);

            if (transform.position.y <= yLimit) {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            PlayerController.isGameOver = true;
        }
    }
}