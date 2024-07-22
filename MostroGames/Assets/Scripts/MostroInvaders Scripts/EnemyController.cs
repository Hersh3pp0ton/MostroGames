using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject bullet;

    private Vector3 offset = new Vector3(0f, -0.5f, 0f);

    private float startDelay = 0.5f, repeatingDelay = 1f;

    void Start() {
        InvokeRepeating("SpawnBullet", startDelay, repeatingDelay);
    }

    void SpawnBullet() {
        if(!PlayerController.isGameOver && !PauseButton.isPaused) {
            Instantiate(bullet, transform.position + offset, bullet.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision) {
        if(collision.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            PlayerController.score++;
        }
    }
}
