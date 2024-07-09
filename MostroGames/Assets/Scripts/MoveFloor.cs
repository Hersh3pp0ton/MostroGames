using UnityEngine;

public class MoveFloor : MonoBehaviour {
    
    Vector3 startPos;
    public float moveSpeed = 5f;
    private float xLimit = -1.2f;

    void Start() {
        startPos = transform.position;
    }

    void Update() {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        if(transform.position.x <= xLimit) {
            transform.position = startPos;
        }
    }
}
