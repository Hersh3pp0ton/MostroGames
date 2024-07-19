using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject[] bullet = new GameObject[3];
    public GameObject pauseCanva;

    public float playerSpeed = 5.0f;

    private float bulletCooldown = 1f;
    private float nextBulletShootTime;

    [HideInInspector] static public bool isMovingLeft = false;
    [HideInInspector] static public bool isMovingRight = false;
    [HideInInspector] static public bool isFiring = false;

    private float limit = 1.9f;
    private float yPos = -2.5f;

    private Vector3 offset = new(0, 0.8f, 0);

    void Update() {
        if(isMovingLeft) {
            transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
        } else if(isMovingRight) {
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        } else if(isFiring && Time.time > nextBulletShootTime) {
            int index = Random.Range(0, 3);
            GameObject bulletShot = Instantiate(bullet[index],
                transform.position + offset,
                bullet[index].transform.rotation);

            nextBulletShootTime = Time.time + bulletCooldown;
        } 
        if(transform.position.x >= limit) {
            transform.position = new(limit, yPos, 0);
        } else if(transform.position.x <= -limit) {
            transform.position = new(-limit, yPos, 0);
        }

        pauseCanva.SetActive(PauseButton.isPaused);
    }
}
