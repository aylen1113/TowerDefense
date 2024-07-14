using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public Transform target; // Target for enemies to move towards
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TMP_Text waveCountdownText;
    public float spawnRange = 3f; // Maximum random offset for spawn positions
    //public GameManager gameManager;

    private int waveIndex = 0;

    void Update()
    {
        // If there are still enemies alive, do not proceed to spawn the next wave
        if (EnemiesAlive > 0)
        {
            return;
        }

        // Uncomment this if you want to stop spawning waves after the last wave
        // if (waveIndex == waves.Length)
        // {
        //     gameManager.WinLevel();
        //     this.enabled = false;
        //     return;
        // }

        // If the countdown is finished, start spawning the next wave
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        // Decrease the countdown timer
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        // Update the countdown display
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        // Check if waveIndex is within the bounds of the waves array
        if (waveIndex >= waves.Length)
        {
            yield break; // Exit if no more waves
        }

        // Get the current wave
        Wave wave = waves[waveIndex];

        // Update the count of enemies alive
        EnemiesAlive = wave.count;

        // Spawn all enemies in the current wave
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        // Move to the next wave
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        // Generate a random position around the spawn point
        Vector3 spawnPosition = spawnPoint.position + new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0f,
            Random.Range(-spawnRange, spawnRange)
        );

        // Instantiate the enemy
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnPoint.rotation);

        // Assign the target to the enemy
        EnemyMovement enemyScript = enemy.GetComponent<EnemyMovement>();
        if (enemyScript != null)
        {
            enemyScript.target = target;
        }
    }
}
