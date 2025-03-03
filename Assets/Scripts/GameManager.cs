using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public UIManager uiManager; 


    public GameObject gameOverScreen;  // Assign in Inspector
    public GameObject gameWinScreen;   // Assign in Inspector

    private bool hasKey = false;

    void Start()
    {
        Time.timeScale = 1f; // Ensure game starts normally
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            TriggerGameOver();
        }
        else if (collision.CompareTag("Key"))
        {
            CollectKey(collision.gameObject);
        }
        else if (collision.CompareTag("Finish"))
        {
            CheckWinCondition();
        }
    }

    void TriggerGameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f; // Stop the game
    }

    void CollectKey(GameObject keyObject)
    {
        hasKey = true;
        Destroy(keyObject); // Remove key after collecting
    }

    void CheckWinCondition()
    {
        if (hasKey)
        {
            gameWinScreen.SetActive(true);
            Time.timeScale = 0f; // Stop the game
        }
    }

    public void PlayAgain()
    {
        Debug.Log("Restart Button Clicked!");
        Time.timeScale = 1f; // Resume time before reloading
        SceneManager.LoadScene(0);
    }
}
