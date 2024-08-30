using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public List<GameObject> collectedItems = new List<GameObject>(); // List to hold collected items
    public TMP_Text inventoryText; // Reference to the TextMeshPro component

    // Method to add an item to the inventory
    public void AddItem(GameObject item)
    {
        collectedItems.Add(item);
        Debug.Log("Item collected: " + item.name);
        UpdateInventoryDisplay(); // Update the inventory display after adding an item
    }

    // Method to get the number of collected items
    public int GetItemCount()
    {
        return collectedItems.Count;
    }

    // Method to update the UI text displaying the number of collected items
    private void UpdateInventoryDisplay()
    {
        if (inventoryText != null)
        {
            inventoryText.text = "Collected Items: " + collectedItems.Count;
        }
    }
}
