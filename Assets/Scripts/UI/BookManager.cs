using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookManager : MonoBehaviour
{
    public GameObject bookUI; 
    private bool isBookOpen = false; // Flag to track whether the book is open or closed
    public GameObject Player; 
    private FPSController fpsController; 

    void Start()
    {
        
        bookUI.SetActive(false);

        
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


