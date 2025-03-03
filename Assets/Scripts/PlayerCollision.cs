using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager; // Manually assign in Inspector

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameManager != null)
        {
            //gameManager.PlayerCollided(other.gameObject);
        }
        else
        {
            Debug.LogError("GameManager is not assigned in the PlayerCollision script!");
        }
    }
}
