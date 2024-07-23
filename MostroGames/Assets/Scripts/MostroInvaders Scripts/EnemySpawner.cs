using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemies = new GameObject[2];
    public GameObject bossPrefab;

    private float startDelay = 2f;
    [HideInInspector] public static float repeatingDelay = 2f;

    [HideInInspector] public static bool isBossWave = false;
    [HideInInspector] public static bool isBossSpawned = false;

    void Start() {
        InvokeRepeating("SpawnEnemy", startDelay, repeatingDelay);
    }

    void Update() {
        if((PlayerController.score % 10 == 0) && PlayerController.score != 0) isBossWave = true;

        if(isBossWave) {
            if(!isBossSpawned) {
                Instantiate(bossPrefab, new(0, 7, 0), bossPrefab.transform.rotation);

                isBossSpawned = true;
            }
        }
    }

    void SpawnEnemy() {
        if(!PlayerController.isGameOver && !PauseButton.isPaused && !isBossWave) {
            int index = Random.Range(0, enemies.Length);
            float xSpawn = Random.Range(-1.8f, 1.8f);
            float ySpawn = Random.Range(0f, 3.5f);
            Vector3 spawnPos = new(xSpawn, ySpawn, 0);
            Instantiate(enemies[index], spawnPos, enemies[index].transform.rotation);
        }
    }
}
