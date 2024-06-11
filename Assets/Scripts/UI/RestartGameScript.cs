using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGameScript : MonoBehaviour
{
    
    public void RestartGame()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        
        SceneManager.LoadScene(currentScene.name);

        Time.timeScale = 1f;
        
        Cursor.visible = false;
        
        Cursor.lockState = CursorLockMode.Locked;
    }
}
