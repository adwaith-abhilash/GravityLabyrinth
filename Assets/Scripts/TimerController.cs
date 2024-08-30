using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public Text timerText; // UI Text to display the timer
    public float timeLimit = 120f; // 2 minutes (120 seconds)
    public string gameWonSceneName = "GameWon"; // Name of the "Game Won" scene
    public string gameOverSceneName = "GameOver"; // Name of the "Game Over" scene

    private float timeRemaining;
    private bool timerIsRunning = false;
    private int totalCollectibles;
    private int collectedItems = 0;

    void Start()
    {
        timeRemaining = timeLimit;
        timerIsRunning = true;
        
        // Count the total number of collectible objects in the scene
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                // Time has run out
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        // Convert time to minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void CollectItem()
    {
        collectedItems++;
        if (collectedItems >= totalCollectibles)
        {
            GameWon();
        }
    }

    void GameWon()
    {
        SceneManager.LoadScene(gameWonSceneName);
    }

    void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}
