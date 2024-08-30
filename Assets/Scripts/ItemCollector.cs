using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Inventory inventory; // Reference to the Inventory script

    void Start()
    {
        if (inventory == null)
        {
            Debug.LogError("Inventory reference not assigned.");
        }
    }

    // Call this method when an item is collected
    public void CollectItem(GameObject item)
    {
        if (inventory != null)
        {
            inventory.AddItem(item); // Add the item to the inventory
        }
    }
}
