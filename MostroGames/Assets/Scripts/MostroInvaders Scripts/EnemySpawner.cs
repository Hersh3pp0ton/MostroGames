using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemies = new GameObject[2];

    private float startDelay = 2f;
    private float repeatingDelay = 2f;

    void Start() {
        InvokeRepeating("SpawnEnemy", startDelay, repeatingDelay);
    }

    void SpawnEnemy() {
        if(!PlayerController.isGameOver && !PauseButton.isPaused) {
            int index = Random.Range(0, enemies.Length);
            float xSpawn = Random.Range(-1.8f, 1.8f);
            float ySpawn = Random.Range(0f, 3.5f);
            Vector3 spawnPos = new(xSpawn, ySpawn, 0);
            Instantiate(enemies[index], spawnPos, enemies[index].transform.rotation);
        }
    }
}
