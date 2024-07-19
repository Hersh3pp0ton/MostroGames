using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject bullet;

    public float playerSpeed = 5.0f;
    public float bulletSpeed = 10.0f;

    [HideInInspector] static public bool isMovingLeft = false;
    [HideInInspector] static public bool isMovingRight = false;
    [HideInInspector] static public bool isFiring = false;

    private float limit = 1.9f;
    private float yPos = -2.5f;

    void Update() {
        if(isMovingLeft) {
            transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
            Debug.Log("Left");
        } else if(isMovingRight) {
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
            Debug.Log("Right");
        } else if(isFiring) {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
            Debug.Log("Up");
        }
        if(transform.position.x >= limit) {
            transform.position = new(limit, yPos, 0);
        } else if(transform.position.x <= -limit) {
            transform.position = new(-limit, yPos, 0);
        }

    }
}
