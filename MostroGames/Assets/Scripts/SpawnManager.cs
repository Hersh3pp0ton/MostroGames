using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject tubePrefab;

    private float startDelayTime = 2f;
    private float repeatingDelay = 1.5f;
    private float xSpawn = 4f;

    void Start() {
        Invoke("SpawnTubes", startDelayTime);   
    }

    void SpawnTubes() {
        if(!PlayerMovement.isGameOver) {
            float ySpawn = Random.Range(-5.35f, -1.7f);
            Instantiate(tubePrefab, new Vector3(xSpawn, ySpawn, 0), Quaternion.identity);
            Invoke("SpawnTubes", repeatingDelay);
        }
    }
}
