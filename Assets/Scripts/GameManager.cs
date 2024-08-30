using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private Timer timer;
    [SerializeField] private int requiredItems = 5;
    [SerializeField] private string gameWonScene = "GameWon";
    [SerializeField] private string gameOverScene = "GameOver";

    // Array to hold all trigger colliders
    [SerializeField] private Collider[] voidTriggers;

    private void Update()
    {
        // Check if the game is won
        if (inventory.GetItemCount() >= requiredItems)
        {
            DisplayGameWonScreen();
        }
        // Check if the game is over due to timer running out
        else if (timer.RemainingTime <= 0)
        {
            DisplayGameOverScreen();
        }
    }

    private void DisplayGameWonScreen()
    {
        SceneManager.LoadScene(gameWonScene);
    }

    private void DisplayGameOverScreen()
    {
        SceneManager.LoadScene(gameOverScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var trigger in voidTriggers)
            {
                if (trigger.bounds.Contains(other.transform.position))
                {
                    Debug.Log("Player entered void area.");
                    DisplayGameOverScreen();
                    return;
                }
            }
        }
    }
}
