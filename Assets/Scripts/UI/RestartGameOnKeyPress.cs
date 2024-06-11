using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameOnKeyPress : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        // Get the current active scene and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        // Resume the game if it was paused
        Time.timeScale = 1f;

        // Make sure the cursor is hidden and locked again (if required)
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
