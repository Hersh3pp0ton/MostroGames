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
        float ySpawn = Random.Range(-2.3f, 1f);
        Instantiate(tubePrefab, new Vector3(xSpawn, ySpawn, 0), Quaternion.Euler(0, 0, 0));
        Invoke("SpawnTubes", repeatingDelay);
    }
}
