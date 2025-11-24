using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public static GameManager Instance;

    public int money = 100;
    public TMP_Text moneyText;

    public Action<int> onMoneyChanged;

    [Header("Game State")]
    public bool gameOver = false;
    public int totalWaves = 5;          
    public int currentWave = 0;

    public GameObject VictoryScreen;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        totalWaves = FindObjectOfType<WaveSpawner>().waves.Length;

    }
    public void EndGame()
    {
        gameOverCanvas.SetActive(true); 
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public bool CanAfford(int amount)
    {
        return money >= amount;
    }

    public void SpendMoney(int amount)
    {
        money -= amount;
        onMoneyChanged?.Invoke(money);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        onMoneyChanged?.Invoke(money);
    }
  

    public void OnWaveCompleted()
    {
        currentWave++;

        if (currentWave >= totalWaves)
        {
            // Si no quedan enemigos → Victoria
            if (WaveSpawner.EnemiesAlive == 0)
            {
                WinGame();
            }
        }
    }
    public void WinGame()
    {
        if (gameOver) return;
        gameOver = true;

        Time.timeScale = 0f; 
        VictoryScreen.SetActive(true);

        Debug.Log("victoria");
    }





}

