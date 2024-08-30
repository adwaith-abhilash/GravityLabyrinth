using UnityEngine;

public class SpriteDisplayController : MonoBehaviour
{
    public GameObject upSprite;
    public GameObject downSprite;
    public GameObject leftSprite;
    public GameObject rightSprite;
    
    public Transform character; // Reference to the character's Transform
    public Transform cameraTransform; // Reference to the camera's Transform

    private GameObject activeSprite = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ShowSprite(upSprite);
            SetGravityAndRotation(new Vector3(0, 180, 180));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ShowSprite(downSprite);
            SetGravityAndRotation(new Vector3(0, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ShowSprite(leftSprite);
            SetGravityAndRotation(new Vector3(0, 180, -90));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShowSprite(rightSprite);
            SetGravityAndRotation(new Vector3(0, 180, 90));
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            HideActiveSprite();
        }
    }

    void ShowSprite(GameObject sprite)
    {
        if (activeSprite != null)
        {
            activeSprite.SetActive(false);
        }

        activeSprite = sprite;
        activeSprite.SetActive(true);
    }

    void HideActiveSprite()
    {
        if (activeSprite != null)
        {
            activeSprite.SetActive(false);
            activeSprite = null;
        }
    }

    void SetGravityAndRotation(Vector3 rotation)
    {
        // Set gravity based on the selected rotation
        Physics.gravity = Quaternion.Euler(rotation) * Vector3.down * 9.81f;

        // Rotate the character to match the gravity direction
        character.rotation = Quaternion.Euler(rotation);

        // Rotate the camera to match the character's orientation
        cameraTransform.rotation = Quaternion.Euler(rotation);
    }
}
