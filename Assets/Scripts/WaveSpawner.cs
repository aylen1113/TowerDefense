using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public Transform target; 
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public TMP_Text waveCountdownText;
    public float spawnRange = 3f; 

    private int waveIndex = 0;

    public static int totalEnemiesKilled = 0;
    public GameObject[] enemyTypes;

    private bool allWavesSpawned = false;

    private void Awake()
    {
        allWavesSpawned = false;
        waveIndex = 0;
        EnemiesAlive = 0;
    }

    void Update()
    {

        if (allWavesSpawned)
            return;


        if (EnemiesAlive > 0)
            return;

        if (waveIndex >= waves.Length)
        {
            allWavesSpawned = true;

            if (EnemiesAlive == 0)
            {
                GameManager.Instance.WinGame();   
            }

            return;
        }


        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = countdown.ToString("00.00");
    }

    IEnumerator SpawnWave()
    {
        GameManager.Instance.OnWaveCompleted(); 

        Wave wave = waves[waveIndex];
        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(GetEnemyForCurrentWave());
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }



    void SpawnEnemy(GameObject enemyPrefab)
    {
        Debug.Log("Spawning enemy");

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

        enemy.tag = "Enemy";
    }
    GameObject GetEnemyForCurrentWave()
    {
        int index = 0;

        if (waveIndex >= 3) index = 1;
        if (waveIndex >= 5) index = 2;
        if (waveIndex >= 10) index = 3;

        return enemyTypes[index];
    }

}
