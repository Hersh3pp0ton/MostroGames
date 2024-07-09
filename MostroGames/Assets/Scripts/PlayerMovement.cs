using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerJumpSpeed = 7f;
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            rb.velocity = new Vector2(0, playerJumpSpeed);
        }
    }
}
