using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }
    public GameObject menuCanvas;
    public GameObject player; // Assign the player GameObject in the inspector
    private FPSController fpsController;
    private bool isOnStart = true;
    [SerializeField] private int bugCount = 0;
    [SerializeField] private TextMeshProUGUI bugCountText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    void ToggleMenu()
    {
        isOnStart = false;
        bool isActive = menuCanvas.activeSelf;
        menuCanvas.SetActive(!isActive);
        Cursor.visible = !isActive;
        Cursor.lockState = isActive ? CursorLockMode.Locked : CursorLockMode.None;
        Time.timeScale = isActive ? 1f : 0f;
        fpsController.enabled = isActive;
    }

    public void CountUpBug()
    {
        bugCount++;
        bugCountText.text = " Insecten gevangen: " + bugCount + "/10";
        if (bugCount >= 10)
        {
            // Trigger win condition
            Debug.Log("You caught 10 bugs! You win!");
        }
    }

}