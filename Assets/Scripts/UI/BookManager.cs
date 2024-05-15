using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject bookUI; // Reference to the UI canvas representing the book
    private bool isBookOpen = false; // Flag to track whether the book is open or closed
    public GameObject Player; // Reference to the player GameObject
    private FPSController fpsController; // Reference to the FPSController script attached to the player

    void Start()
    {
        // Ensure the book UI is initially disabled
        bookUI.SetActive(false);

        // Get the FPSController script attached to the player GameObject
        fpsController = Player.GetComponent<FPSController>();
    }

    void Update()
    {
        // Check for player input to toggle the book
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleBook();
        }
    }

    void ToggleBook()
    {
        // Toggle the state of the book and update UI accordingly
        isBookOpen = !isBookOpen;
        bookUI.SetActive(isBookOpen);

        // Toggle cursor visibility
        Cursor.visible = isBookOpen;

        // Optionally, you can also lock or unlock the cursor
        if (isBookOpen)
        {
            Cursor.lockState = CursorLockMode.None; // Unlock cursor when book is open
            // Disable the FPSController script
            fpsController.enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock cursor when book is closed
            // Enable the FPSController script
            fpsController.enabled = true;
        }
    }
}
