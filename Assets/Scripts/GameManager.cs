using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver = false;
    public GameObject gameOverUI;
    public TMP_Text gameOverText; 

    void Update()
    {
        if (gameIsOver)
            return;

        // Example condition to trigger game over
        // You can set gameIsOver to true based on your own condition
        // if (playerHealth <= 0)
        // {
        //     EndGame();
        // }
    }

    public void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
     
        Debug.Log("Game Over");
    }

    public void Restart()
    {
        gameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit(); 
    }
}
