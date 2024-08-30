using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidCollisionHandler : MonoBehaviour
{
    // Set the layer number for "Void" in the Inspector or programmatically
    [SerializeField] private int voidLayer = 8; // Assuming "Void" is layer 8, you can adjust this value

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object the player collided with is on the "Void" layer
        if (collision.gameObject.layer == voidLayer)
        {
            Debug.Log("Player has collided with the void. Loading Game Over scene.");
            SceneManager.LoadScene("gameOverScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object the player triggered is on the "Void" layer
        if (other.gameObject.layer == voidLayer)
        {
            Debug.Log("Player has entered the void. Loading Game Over scene.");
            SceneManager.LoadScene("gameOverScene");
        }
    }
}
