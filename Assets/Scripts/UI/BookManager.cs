using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookManager : MonoBehaviour
{
    public GameObject bookUI; 
    private bool isBookOpen = false; 
    public GameObject Player; 
    private FPSController fpsController; 

    void Start()
    {
        
        bookUI.SetActive(false);
        fpsController = Player.GetComponent<FPSController>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleBook();
        }
    }

    void ToggleBook()
    {
        
        isBookOpen = !isBookOpen;
        bookUI.SetActive(isBookOpen);
        Cursor.visible = isBookOpen;

        
        if (isBookOpen)
        {
            Cursor.lockState = CursorLockMode.None;  
            fpsController.enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; 
            fpsController.enabled = true;
        }
    }
}


