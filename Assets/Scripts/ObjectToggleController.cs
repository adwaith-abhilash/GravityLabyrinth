using UnityEngine;
using Cinemachine;

public class ObjectToggleController : MonoBehaviour
{
    public GameObject[] sprites; // Array to hold the 4 holographic sprites
    public CinemachineFreeLook freeLookCamera; // Reference to the Cinemachine FreeLook Camera
    private GameObject currentSprite = null; // Reference to the currently displayed sprite

    public float gravityStrength = 9.81f; // Strength of the gravity
    public float cameraRotationSpeed = 1f; // Speed of camera rotation

    private Quaternion defaultCameraRotation;

    void Start()
    {
        // Store the default camera rotation
        if (freeLookCamera != null)
        {
            defaultCameraRotation = freeLookCamera.transform.rotation;
        }

        // Ensure all sprites are initially inactive
        foreach (GameObject sprite in sprites)
        {
            sprite.SetActive(false);
        }
    }

    void Update()
    {
        // Handle sprite display based on arrow keys
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            DisplaySprite(0, Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DisplaySprite(1, Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            DisplaySprite(2, Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DisplaySprite(3, Vector3.down);
        }

        // Handle sprite disappearance and reset gravity with Enter key
        if (Input.GetKeyDown(KeyCode.Return))
        {
            HideCurrentSprite();
        }
    }

    void DisplaySprite(int index, Vector3 gravityDirection)
    {
        // Deactivate the currently displayed sprite if any
        if (currentSprite != null)
        {
            currentSprite.SetActive(false);
        }

        // Activate the new sprite
        currentSprite = sprites[index];
        currentSprite.SetActive(true);
        currentSprite.transform.position = transform.position + gravityDirection * 2f; // Position sprite relative to character

        // Update gravity and camera orientation
        SetGravity(gravityDirection);
        UpdateCameraOrientation(gravityDirection);
    }

    void HideCurrentSprite()
    {
        if (currentSprite != null)
        {
            currentSprite.SetActive(false);
            currentSprite = null; // Clear reference to the current sprite
            // Reset gravity to default (downward)
            SetGravity(Vector3.down);
            UpdateCameraOrientation(Vector3.down);
        }
    }

    void SetGravity(Vector3 direction)
    {
        // Set global gravity direction
        Physics.gravity = direction * gravityStrength;
    }

    void UpdateCameraOrientation(Vector3 direction)
    {
        if (freeLookCamera != null)
        {
            // Calculate desired camera rotation
            Quaternion targetRotation = Quaternion.LookRotation(-direction, Vector3.up);
            
            // Adjust the camera's orbits based on the new gravity direction
            freeLookCamera.m_Orbits[0].m_Height = Mathf.Abs(freeLookCamera.m_Orbits[0].m_Height);
            freeLookCamera.m_Orbits[1].m_Height = Mathf.Abs(freeLookCamera.m_Orbits[1].m_Height);
            freeLookCamera.m_Orbits[2].m_Height = Mathf.Abs(freeLookCamera.m_Orbits[2].m_Height);
            
            // Apply smooth rotation to camera
            freeLookCamera.transform.rotation = Quaternion.Slerp(freeLookCamera.transform.rotation, targetRotation, cameraRotationSpeed * Time.deltaTime);
        }
    }
}
