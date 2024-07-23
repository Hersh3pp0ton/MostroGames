using UnityEngine;

public class BossController : MonoBehaviour {

    public GameObject bullet;

    private int lifePoints = 10;

    [HideInInspector] public static bool isBossDead = false;

    private Vector3 offset = new(-0.16f, -1.5f, 0f);

    void Start() {
        Invoke("EnemyAttackHandler", 3);
    }

    void Update() {
        if(lifePoints <= 0) {
            Destroy(gameObject);
            isBossDead = true;
            PlayerController.score += 3;
            EnemySpawner.isBossWave = false;
            EnemySpawner.isBossSpawned = false;
            EnemySpawner.repeatingDelay -= 0.50f;
            EnemyBulletController.bulletSpeed += 0.50f;
        }
    }

    void EnemyAttackHandler() {
        int probability = Random.Range(1, 101);

        if(probability >= 70) {
            SpecialAttack();
        } else {
            FireBullet();
        }

        Invoke("EnemyAttackHandler", 1f);
    }

    void FireBullet() {
        if(!PlayerController.isGameOver && !PauseButton.isPaused) {
            Instantiate(bullet, transform.position + offset, bullet.transform.rotation);
        }
    }

    void SpecialAttack() {
        if (!PlayerController.isGameOver && !PauseButton.isPaused) {
            Instantiate(bullet, transform.position + offset,
                Quaternion.Euler(0f, 0f, -30f));
            Instantiate(bullet, transform.position + offset,
                Quaternion.Euler(0f, 0f, 30f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Bullet")) {
            Destroy(collision.gameObject);
            lifePoints--;
        }
    }
}
