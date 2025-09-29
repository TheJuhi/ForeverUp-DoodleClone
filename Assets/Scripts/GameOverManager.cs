using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; // pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // reset time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

