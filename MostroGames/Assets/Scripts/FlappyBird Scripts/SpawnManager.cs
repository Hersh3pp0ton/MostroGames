using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject tubePrefab;
    [HideInInspector] public static GameObject coppiaTubi;

    private float startDelayTime = 2f;
    private float repeatingDelay = 1f;
    private float xSpawn = 4f;

    void Start() {
        InvokeRepeating("SpawnTubes", startDelayTime, repeatingDelay);
    }

    void SpawnTubes() {
        if(!PlayerMovement.isGameOver && !PauseButton.isPaused) {
            float ySpawn = Random.Range(-5.35f, -1.7f);
            coppiaTubi = Instantiate(tubePrefab, new Vector3(xSpawn, ySpawn, 0), 
                Quaternion.identity);
        }
    }
}
