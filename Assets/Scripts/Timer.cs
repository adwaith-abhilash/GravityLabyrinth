using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText; // Reference to the TextMeshPro component
    [SerializeField] private float initialTime = 120f; // Starting time in seconds
    public float RemainingTime { get; private set; } // Public property for remaining time

    private void Start()
    {
        RemainingTime = initialTime;
    }

    private void Update()
    {
        RemainingTime -= Time.deltaTime;
        RemainingTime = Mathf.Max(RemainingTime, 0); // Ensure time doesn't go below 0
        int minutes = Mathf.FloorToInt(RemainingTime / 60);
        int seconds = Mathf.FloorToInt(RemainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
