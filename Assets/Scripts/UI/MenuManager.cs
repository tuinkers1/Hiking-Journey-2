using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject player;
    private FPSController fpsController;
    private bool isOnStart = true;

    void Start()
    {
        fpsController = player.GetComponent<FPSController>();
        if (fpsController == null)
        {
            Debug.LogError("FPSController component not found on the player.");
        }

        menuCanvas.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        fpsController.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isOnStart == true)
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        isOnStart = false;
        bool isActive = menuCanvas.activeSelf;
        menuCanvas.SetActive(!isActive);
        Cursor.visible = !isActive;
        Cursor.lockState = isActive ? CursorLockMode.Locked : CursorLockMode.None;
        Time.timeScale = isActive ? 1f : 0f;
        fpsController.enabled = isActive;
    }

    public bool IsMenuActive() // Add this method
    {
        return menuCanvas.activeSelf;
    }
}
