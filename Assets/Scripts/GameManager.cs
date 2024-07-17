using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    public void EndGame()
    {
        if (gameEnded)
            return;

        gameEnded = true;
        Debug.Log("Game Over");
     
        Invoke("Restart", 2f); // Restart the game after a delay
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
