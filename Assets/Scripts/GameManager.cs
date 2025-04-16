using UnityEngine;
using UnityEngine.SceneManagement; // For reloading the scene
using UnityEngine.UI; // For accessing UI elements

public class GameManager : MonoBehaviour
{
    public PlayerMovement playerMovement;  // Ensure this is public
    public GameObject gameOverUI;

    public void GameOver()
    {
        // Disable player movement by turning off the PlayerMovement script
        playerMovement.enabled = false;  
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;  // Freeze the game
    }
}
