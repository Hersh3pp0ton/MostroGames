using UnityEngine;

public class MoveTubes : MonoBehaviour {

    private float moveSpeed = 5f;
    private float xLimit = -4f;

    void Update() {
        if(!PlayerMovement.isGameOver) {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x < xLimit) {
                Destroy(gameObject);
            }
        }
    }
}
