using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public UIManager uiManager; 


    public GameObject gameOverScreen; 
    public GameObject gameWinScreen;   

    private bool hasKey = false;

    void Start()
    {
        Time.timeScale = 1f; 
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
        Cursor.lockState = CursorLockMode.None;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f; 
    }

    void CollectKey(GameObject keyObject)
    {
        hasKey = true;
        Destroy(keyObject); 
    }

    void CheckWinCondition()
    {
        if (hasKey)
        {
            gameWinScreen.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void PlayAgain()
    {
        Debug.Log("Restart Button Clicked!");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
