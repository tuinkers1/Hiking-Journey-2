
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageSwitch : MonoBehaviour
{
    public string englishSceneName = "ENGLISH";
    public string dutchSceneName = "DUTCH";

    public void SwitchScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == englishSceneName)
        {
            SceneManager.LoadScene(dutchSceneName);
        }
        else if (currentSceneName == dutchSceneName)
        {
            SceneManager.LoadScene(englishSceneName);
        }
    }
}
