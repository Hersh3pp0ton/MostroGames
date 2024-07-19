using UnityEngine;

public class BulletController : MonoBehaviour {

    private float bulletSpeed = 7.5f;
    private float yLimitForBullet = 7f;

    private void Update() {
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);

        if (transform.position.y >= yLimitForBullet) {
            Destroy(gameObject);
        }
    }  
}
