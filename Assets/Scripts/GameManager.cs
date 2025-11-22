using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public static GameManager Instance;

    public int money = 100;

    public Action<int> onMoneyChanged;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        gameOverCanvas.SetActive(false);
    }
    public void EndGame()
    {
        gameOverCanvas.SetActive(true); 
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
}

