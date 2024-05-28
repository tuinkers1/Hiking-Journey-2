using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject bookUI;
    private bool isBookOpen = false;
    public GameObject player;
    private FPSController fpsController;
    public GameObject animationRoot;
    private SwingTrigger swingTrigger;
    public MenuManager menuManager; // Add this line

    void Start()
    {
        bookUI.SetActive(false);
        fpsController = player.GetComponent<FPSController>();
        swingTrigger = animationRoot.GetComponent<SwingTrigger>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !menuManager.IsMenuActive()) // Update this line
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
            swingTrigger.enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            fpsController.enabled = true;
            swingTrigger.enabled = true;
        }
    }
}
