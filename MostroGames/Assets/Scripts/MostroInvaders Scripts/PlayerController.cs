using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject[] bullet = new GameObject[3];
    public GameObject pauseCanva;
    public GameObject gameOverCanva;
    public Text scoreText;

    private AudioSource audioSource;
    public AudioClip onBossDeath;
    public AudioClip onEnemyDeath;
    public AudioClip fireSound;

    [HideInInspector] public static int score = 0;
    [HideInInspector] public static bool playGameOverSound = false;

    public float playerSpeed = 5.0f;

    private float bulletCooldown = 1f;
    private float nextBulletShootTime;

    [HideInInspector] public static bool isGameOver = false;

    [HideInInspector] public static bool isMovingLeft = false,
        isMovingRight = false, 
        isFiring = false;

    private float limit = 1.9f;
    private float yPos = -2.5f;

    private Vector3 offset = new(0, 0.8f, 0);

    void Start() {
        audioSource = GetComponent<AudioSource>();    
    }

    void Update() {
        if(!isGameOver && !PauseButton.isPaused) {
            if (isMovingLeft || Input.GetKey(KeyCode.LeftArrow)) {
                transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);

            } if (isMovingRight || Input.GetKey(KeyCode.RightArrow)) {
                transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);

            }  if ((isFiring || Input.GetKey(KeyCode.UpArrow)) 
                && Time.time > nextBulletShootTime) {

                audioSource.PlayOneShot(fireSound);

                int index = Random.Range(0, 3);
                GameObject bulletShot = Instantiate(bullet[index],
                    transform.position + offset,
                    bullet[index].transform.rotation);

                nextBulletShootTime = Time.time + bulletCooldown;
            }

            if (transform.position.x >= limit) {
                transform.position = new(limit, yPos, 0);

            } else if (transform.position.x <= -limit) {
                transform.position = new(-limit, yPos, 0);
            }

            scoreText.text = score.ToString();

            if(BossController.isBossDead) {
                audioSource.PlayOneShot(onBossDeath);
                BossController.isBossDead = false;
            }
            if(EnemyController.isEnemyDead) {
                audioSource.PlayOneShot(onEnemyDeath);
                EnemyController.isEnemyDead = false;
            }
        }

        gameOverCanva.SetActive(isGameOver);
        pauseCanva.SetActive(PauseButton.isPaused);
    }
}
