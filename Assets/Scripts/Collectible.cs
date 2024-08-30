using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string itemName; // Name of the collectible item
    public AudioSource audioSource; // Reference to the AudioSource

    private void OnTriggerEnter(Collider other)
    {
        // Check if the character collided with the collectible
        if (other.CompareTag("Player"))
        {
            // Get the Inventory component from the character
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                // Add the item to the inventory
                inventory.AddItem(gameObject);

                // Play the audio clip
                if (audioSource != null)
                {
                    audioSource.Play();
                    Debug.Log("Playing sound: " + audioSource.clip.name);
                }
                else
                {
                    Debug.LogWarning("No AudioSource attached to " + gameObject.name);
                }

                // Optionally, destroy the collectible object
                Destroy(gameObject, audioSource.clip.length); // Destroys after the sound finishes playing
            }
        }
    }
}
