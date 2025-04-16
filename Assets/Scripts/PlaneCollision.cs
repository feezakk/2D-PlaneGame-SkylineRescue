using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    public GameManager gameManager; // Assign the GameManager in the Inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BirdObstacle"))
        {
            // Trigger Game Over
            gameManager.GameOver();
        }
    }
}